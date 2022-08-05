using Assets.Scripts;
using UnityEngine;

public class Missile : MonoBehaviour
{
    private float _damage;
    private float _powerOfExplotion;
    private float _radiousOfExplosion;

    private AudioSource _audioSource;
    private IExplodable _explodable;

    private void Start()
    {
         _audioSource = GetComponent<AudioSource>(); 
    }

    public void InitializeMissle(float damage, float powerOfExplotion, float radiousOfExplosion, IExplodable explodable)
    {
        _damage = damage;
        _powerOfExplotion = powerOfExplotion;
        _radiousOfExplosion = radiousOfExplosion;
        _explodable = explodable;
    }

    private void OnCollisionEnter(Collision collision)
    {
        _explodable.Explosion(gameObject.transform.position, _radiousOfExplosion, _powerOfExplotion, gameObject, _damage);
        _audioSource.Play();
        Destroy(gameObject);
    }
}
