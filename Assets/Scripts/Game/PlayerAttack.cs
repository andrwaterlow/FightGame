using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float _range = 50;
    [SerializeField] private float _frequency = 0.0001f;
    [SerializeField] private TriggerForPlayer _triggerForPlayer;

    private Player _player;
    private Transform _nearEnemy;
    private Collider[] _objectsOnPlace;
    private Dictionary<float, Enemy> _enemyAndPoses;
    private float _minDastance;
    private float _currentDistance;
    private float[] _allEnemyDistance;
    private bool _beginAttack = false;
    private bool _playerOnplace = false;
    private bool _isBisy = false;


    private void Start()
    {
        _player = FindObjectOfType<Player>();
        _enemyAndPoses = new Dictionary<float, Enemy>();
        _triggerForPlayer = FindObjectOfType<TriggerForPlayer>();
    }

 

    private void Update()
    {
        if (_triggerForPlayer.PlayerOnPlaceOrNot())
        {
            FindAllCollisionsInScene();
            StartCoroutine(FindNearestEnemy());
        }
        if (!_triggerForPlayer.PlayerOnPlaceOrNot())
        {
            _beginAttack = _playerOnplace;
        }
    }

    private IEnumerator FindNearestEnemy()
    {
        if (!_isBisy)
        {
            BisyBegin();
            CreateNewDistanceArray();
            
            for (int i = 0; i < _objectsOnPlace.Length; i++)
            {
                if (_objectsOnPlace[i].TryGetComponent<Enemy>(out Enemy enemy))
                {
                    CalculateDistanceEnemyToPlayer(enemy);
                    WriteDistanceInArray(i);
                    ConfermentCurrentDistanceToEnemy(enemy);
                }
                if (i == _objectsOnPlace.Length - 1)
                {
                    FindMinDistanceAndEnemy();
                }
            }

            yield return new WaitForSeconds(_frequency);
            _enemyAndPoses.Clear();
            BisyEnd();
        }  
    }

    private void FindAllCollisionsInScene()
    {
        var PlaceForSphere = 0;
        _objectsOnPlace = Physics.OverlapSphere(gameObject.transform.
           GetChild(PlaceForSphere).transform.position, _range);
    }

    private void CreateNewDistanceArray()
    {
        _allEnemyDistance = new float[_objectsOnPlace.Length];
    }

    private void CalculateDistanceEnemyToPlayer(Enemy enemy)
    {
        _currentDistance = Mathf.Abs(enemy.transform.position.magnitude -
           _player.transform.position.magnitude);
    }

    private void WriteDistanceInArray(int i)
    {
        _allEnemyDistance[i] = _currentDistance;
    }

    private void ConfermentCurrentDistanceToEnemy(Enemy enemy)
    {
        _enemyAndPoses.TryAdd(_currentDistance, enemy);
    }

    private void FindMinDistanceAndEnemy()
    {
        DeleteAllZero();
        _minDastance = Mathf.Min(_allEnemyDistance);

        if (_minDastance <= _range)
        {
            for (int j = 0; j < _allEnemyDistance.Length; j++)
            {
                if (_minDastance == _allEnemyDistance[j])
                {
                    var placeForShot = 0;
                    _enemyAndPoses.TryGetValue(_minDastance, out var enemy);
                    if (enemy == null)
                    {
                        return;
                    }
                    if (enemy.isActiveAndEnabled)
                    {
                        SetNearEnemy(enemy.transform.GetChild(placeForShot));
                        _beginAttack = true;
                    } 
                }
            }
        }
        else
        {
            _beginAttack = false;
        }
    }

    private void DeleteAllZero()
    {
        var largeNumber = 1000;
        for (int i = 0; i < _allEnemyDistance.Length; i++)
        {
            if (_allEnemyDistance[i] == 0)
            {
                _allEnemyDistance[i] = largeNumber;
            } 
        }
    }

    private void BisyBegin()
    {
        _isBisy = true;
    }

    private void BisyEnd()
    {
        _isBisy = false;
    }

    private void SetNearEnemy(Transform enemy)
    {
        _nearEnemy = enemy;
    }

    public Transform GetNearEnemy()
    {
        if (_nearEnemy == null)
        {
            return gameObject.transform;
        }
        return _nearEnemy;
    }

    public bool AttackOrNot()
    {
        return _beginAttack;
    }
}
