using System;
using UnityEngine;
using UnityEngine.AI;

public class MovementEnemy : MonoBehaviour
{
    [SerializeField] private Transform[] _listOfPoints;
    [SerializeField] private float _speedRotation;

    private WayPoints _wayPoints;
    private NavMeshAgent _navMeshAgent;
    private System.Random _randomIndexOfWayPont;
    private Transform _lastWayPoint;
    private int _currentWaypointIndex;

    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _wayPoints = FindObjectOfType<WayPoints>();
        _randomIndexOfWayPont = new System.Random();
        _listOfPoints = _wayPoints.FillUpListOfWayPoints(_listOfPoints);
    }

    public void AttackPlayer(bool isAlive, bool playerOnTrigger, Transform playerPositions)
    {
        if (isAlive && playerOnTrigger && gameObject.activeInHierarchy)
        {
            _navMeshAgent.SetDestination(playerPositions.position);
        }
        if (!isAlive)
        {
            _navMeshAgent.SetDestination(gameObject.transform.position);
        }
    }

    public void UseNormalWay(bool isAlive)
    {
        if (isAlive && gameObject.activeInHierarchy)
        {
            if (_navMeshAgent.remainingDistance < _navMeshAgent.stoppingDistance)
            {
                _currentWaypointIndex = _randomIndexOfWayPont.Next(0, _listOfPoints.Length - 1);
                _navMeshAgent.SetDestination(_listOfPoints[_currentWaypointIndex].position);
                WriteLastWayPoint(_listOfPoints[_currentWaypointIndex]);
            }
        }
        if (!isAlive)
        {
            _navMeshAgent.SetDestination(gameObject.transform.position);
        }
    }

    public void PlayerLost()
    {
        if (gameObject.activeInHierarchy)
        {
            if (_lastWayPoint == null)
            {
                return;
            }
            _navMeshAgent.SetDestination(_lastWayPoint.position);
        }   
    }

    private void WriteLastWayPoint(Transform wayPoint)
    {
        _lastWayPoint = wayPoint;
    }    
}
