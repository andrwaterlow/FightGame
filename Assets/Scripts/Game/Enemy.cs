using System.Collections;
using UnityEngine;

public class Enemy : MortalObject, IDamagable
{
    private ParticleSystem _particleSystem;
    private AudioSource audioSource;
    private Animator _animator;
    private MovementEnemy _movementEnemy;
    private TriggerAttack _triggerAttack;
    private SpawnerObjects _spawnerObjects;

    private bool _activeAmmo = false;

    public void Awake()
    {
        _particleSystem = GetComponent<ParticleSystem>();
        audioSource = GetComponent<AudioSource>();
        _animator = GetComponent<Animator>();
        _movementEnemy = GetComponent<MovementEnemy>();
        _triggerAttack = FindObjectOfType<TriggerAttack>();
        _triggerAttack.PlayerLost += ForgetPlayer;
        _spawnerObjects = FindObjectOfType<SpawnerObjects>();
    }

    private void ForgetPlayer()
    {
        _movementEnemy.PlayerLost();
    }

    private void Update()
    {
        _movementEnemy.UseNormalWay(_isAlive);
        _movementEnemy.AttackPlayer(_isAlive, _triggerAttack.PlayerOnTriggerOrNot(),
            _triggerAttack.GetPlayerPosition());
    }

    private void DeathOrLive()
    {
        if (!_isAlive)
        {
            StartCoroutine(Death());
        }
    }

    IEnumerator Death()
    {
        var waitingTime = 3f;
        GetComponent<CapsuleCollider>().enabled = false;
        GetComponent<Animator>().enabled = false;
        gameObject.transform.GetChild(0).GetComponent<BoxCollider>().enabled = false;
        _spawnerObjects.SpawnSomethingObjects(gameObject.transform);
        yield return new WaitForSeconds(waitingTime);
        gameObject.SetActive(false);
    }

    public void MakeDamage(float damage)
    {
        _damage.TakeDamage(damage);
        _particleSystem.Play();
        _isAlive = _damage.CheckLiveStatus();
        DeathOrLive();
    }

    public GameObject GetEnemy()
    {
        return gameObject;
    }

    public void ActiveAllComponents()
    {
        _particleSystem.gameObject.SetActive(true);
        audioSource.gameObject.SetActive(true);
        _animator.gameObject.SetActive(true);
        _movementEnemy.gameObject.SetActive(true);
        _triggerAttack.gameObject.SetActive(true);
        gameObject.GetComponent<Animator>().enabled = true;
        gameObject.GetComponent<CapsuleCollider>().enabled = true;
        gameObject.transform.GetChild(0).GetComponent<BoxCollider>().enabled = true;
    }
}
