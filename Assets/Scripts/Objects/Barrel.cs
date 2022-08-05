using Assets.Scripts;
using System.Collections;
using UnityEngine;

public class Barrel : MortalObject, IDamagable
{
    [SerializeField] private int _damageExplode = 100;
    [SerializeField] private float _powerOfExplotion = 500f;
    [SerializeField] private float _distance = 15f;

    private Explodable _explodable;

    new private void Start()
    {
        _health = new Health(50f,50f);
        _armour = new Armour(0f, 0f);
        _damage = new Damage(_health, _armour);
        _isAlive = true;
        _explodable = new Explodable();
    }

    private void DeathOrLive()
    {
        if (!_isAlive)
        {
            Explosion();
            Death();
        }
    }

    private void Explosion()
    {
        if (!_explodable.Exploded)
        {
            _explodable.Explosion(gameObject.transform.position, _distance,
            _powerOfExplotion, gameObject, _damageExplode);
        }
    }

    public void MakeDamage(float damage)
    {
        if (_isAlive)
        {
            _damage.TakeDamage(damage);
            _isAlive = _damage.CheckLiveStatus();
            DeathOrLive();
        }
    }
}
