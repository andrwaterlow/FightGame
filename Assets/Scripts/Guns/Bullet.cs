using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speedOfBullet = 30;
    [SerializeField] private float _timeOfLive = 0.9f;

    private Transform _enemyTransform;
    private bool _isAttacking;
    private float _bulletDamage;
    private bool _enemyIsActive;

    private void Update()
    {
        if (_isAttacking && _enemyIsActive)
        {
            AttackToEnemy();
        }  
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent<Enemy>(out var enemy))
        {
            enemy.GetComponent<IDamagable>().MakeDamage(_bulletDamage);
            Destroy(gameObject);
        }
    }

    public void Initital(float damage)
    {
        _bulletDamage = damage;
        StartCoroutine(TimeOfLive());
    }

    private IEnumerator TimeOfLive()
    {
        yield return new WaitForSeconds(_timeOfLive);
        Destroy(gameObject);
    }

    public void AttackToEnemy()
    {
        transform.position = Vector3.MoveTowards(transform.position, _enemyTransform.position, _speedOfBullet * Time.deltaTime);
    }

    public void GetEnemyTransform(Transform enemyPosition, bool isAttacking)
    {
        _enemyTransform = enemyPosition;
        _isAttacking = isAttacking;
        EnemyActiveOrNot(enemyPosition);
    }

    private void EnemyActiveOrNot(Transform enemyPosition)
    {
        _enemyIsActive = enemyPosition.parent.gameObject.activeInHierarchy;
    }
}
