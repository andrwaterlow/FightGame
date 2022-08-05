using Assets.Scripts;
using UnityEngine;

public class MortalObject : MonoBehaviour
{
    protected ITakeDamage _damage;
    protected Health _health;
    protected Armour _armour;
    protected bool _isAlive;

    public void Start()
    {
        _isAlive = true;
        _health = new Health(100f,100f);
        _armour = new Armour(100f,0f);
        _damage = new Damage(_health, _armour);
    }

    protected void Death()
    {
        Destroy(gameObject);
    }

    public void RecoverEnemy()
    {
        _health._currentHealth = 100;
    }
}