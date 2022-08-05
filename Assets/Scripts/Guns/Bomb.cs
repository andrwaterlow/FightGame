using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private float _time;
   
    private List<Enemy> _enemies = new List<Enemy>();
    private List<Player> _friendlyFire = new List<Player>();
    [SerializeField] private int _damage = 80;



    public void Init(float time)
    {
        _time = time;


    }
    private void Update()
    {
        _time -= Time.deltaTime;
        if (_time <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void Explosion()
    {
        
            foreach (var enemy in _enemies)
            {
               enemy.GetComponent<ITakeDamage>().TakeDamage(_damage);
            }
        
           
        
            foreach (var player in _friendlyFire)
            {
                player.GetComponent<ITakeDamage>().TakeDamage(_damage);
            }
        

        
    }
   
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            _enemies.Add(other.GetComponent<Enemy>());
        }

        if (other.CompareTag("Player"))
        {
            _friendlyFire.Add(other.GetComponent<Player>());
        }
        if (other.CompareTag("AmmoBoxes"))
        {
            _friendlyFire.Add(other.GetComponent<Player>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            _enemies.Remove(other.GetComponent<Enemy>());
        }
        if (other.CompareTag("Player"))
        {
            _friendlyFire.Remove(other.GetComponent<Player>());
        }
    }

    private void OnDestroy()
    {
        Explosion();
    }

    
}
