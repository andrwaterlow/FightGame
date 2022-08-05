using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private byte _difficult;
    [SerializeField] private byte _pauseTime;
    [SerializeField] private byte _roundTime;
    [SerializeField] private int _timeForCreateEnemy;
    [SerializeField] private Transform[] _placeForSpawn;

    private SpawnerEnemy _spawner;
    private System.Random _random;

    private int _valueTime = 1; 
    private bool _isGaming;
    private bool _waitingForCreateEnemy;
    private string _timeBeforeRound;
 
    void Start()
    {
        _spawner = FindObjectOfType<SpawnerEnemy>();
        _random = new System.Random();
    }

    public string GetTime()
    {
        return _timeBeforeRound;
    }

    void Update()
    {

        if (_isGaming && !_waitingForCreateEnemy)
        {
            StartCoroutine(CreateOneEnemyOnTime());
        }
        
    }

    public void StartGame()
    {
        if (!_isGaming)
        {
            StartFight();
            StartCoroutine(TimeCounterForPauseBeforeRound());
        }
    }

    private IEnumerator TimeCounterForPauseBeforeRound()
    {
        for (int i = _pauseTime; i >= 0 ; i--)
        {
            yield return new WaitForSeconds(_valueTime);
            CounterForInterface(i);
        }
        CreateAllEnemy();
        StartCoroutine(TimeCounterForRound());
    }

    private void CounterForInterface(int currenTimeBoreRound)
    {
        string finalPhrase = $"GO!";
        string beginningPhrase = $"Start over ";

        if (currenTimeBoreRound > 0)
        {
            _timeBeforeRound = beginningPhrase + currenTimeBoreRound.ToString();
        }
        else
        {
            _timeBeforeRound = finalPhrase;
            StartCoroutine(ClearText());
        }
    }

    private IEnumerator ClearText()
    {
        yield return new WaitForSeconds(_valueTime);
        _timeBeforeRound = string.Empty;
    }

    private void CreateAllEnemy()
    {
        var randomPlaceForSpawn = _random.Next(0, _placeForSpawn.Length - 1);

        for (int i = 0; i < _difficult; i++)
        {
            _spawner.SpawnEnemy(_placeForSpawn[randomPlaceForSpawn]);
            randomPlaceForSpawn = _random.Next(0, _placeForSpawn.Length - 1);
        }
    }

    private IEnumerator CreateOneEnemyOnTime()
    {
        StartCreatingEnemy();
        yield return new WaitForSeconds(_timeForCreateEnemy);
        var randomPlaceForSpawn = _random.Next(0, _placeForSpawn.Length - 1);
        _spawner.SpawnEnemy(_placeForSpawn[randomPlaceForSpawn]);
        EndCreatingEnemy();
    }

    private IEnumerator TimeCounterForRound()
    {
        for (int i = _roundTime; i >= 0; i--)
        {
            yield return new WaitForSeconds(_valueTime);
        }
        StartCoroutine(TimeCounterForPauseBeforeRound());
        StopCoroutine(CreateOneEnemyOnTime());
        ClearEnemyList();
        LevelUp();
    }

    private void StartFight()
    {
        _isGaming = true;
    }

    private void ClearEnemyList()
    {
        _spawner.DeleteAllEnemy();
    }

    private void LevelUp()
    {
        _difficult++;
    }

    private void StartCreatingEnemy()
    {
        _waitingForCreateEnemy = true;
    }

    private void EndCreatingEnemy()
    {
        _waitingForCreateEnemy = false; ;
    }
}
