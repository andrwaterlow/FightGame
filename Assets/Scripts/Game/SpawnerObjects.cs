using Assets.Scripts;
using System;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerObjects : MonoBehaviour
{
    private GameObject _prefabAmmo;
    private GameObject _prefabMoney;
    private GameObject _prefabHealth;
    private List<Ammo> _ammoes;
    private List<Banknotes> _money;
    private List<FirstAid> _healths;
    private int _probability = 25;
    private Creator _creator;
    private System.Random _random;

    void Start()
    {
        _prefabAmmo = Resources.Load<GameObject>("Ammo");
        _prefabHealth = Resources.Load<GameObject>("Health");
        _prefabMoney = Resources.Load<GameObject>("Money");
        _ammoes = new List<Ammo>();
        _money = new List<Banknotes>();
        _healths = new List<FirstAid>();
        _creator = FindObjectOfType<Creator>();
        _random = new System.Random();
    }

    public void SpawnSomethingObjects(Transform placeForSpawn)
    {
        var currentProbability = _random.Next(0, 101);
        Debug.Log(currentProbability); 
        SpawnMoney(currentProbability, placeForSpawn);
        SpawnVoid(currentProbability, placeForSpawn);
        SpawnHealth(currentProbability, placeForSpawn);
        SpawnAmmo(currentProbability, placeForSpawn);
    }

    private void SpawnMoney(int currentProbability, Transform placeForSpawn)
    {
        if (_probability * 3 <= currentProbability && _probability * 4 >= currentProbability)
        {
            var money = _creator.GetOrCreateObject(_prefabMoney, placeForSpawn).
            GetComponent<Banknotes>();
            money.OnDeath += OnDestroyMoney;
            _money.Add(money);
        }
    }
  
    private void SpawnVoid(int currentProbability, Transform placeForSpawn)
    {
        if (_probability * 2 <= currentProbability && _probability * 3 >= currentProbability)
        {
            return;
        }
    }

    private void SpawnHealth(int currentProbability, Transform placeForSpawn)
    {
        if (_probability <= currentProbability && _probability * 2 >= currentProbability)
        {
            var health = _creator.GetOrCreateObject(_prefabHealth, placeForSpawn).
            GetComponent<FirstAid>();
            health.OnDeath += OnDestroyHealth;
            _healths.Add(health);
        }
    }

    private void SpawnAmmo(int currentProbability, Transform placeForSpawn)
    {
        if (0 <= currentProbability && currentProbability <= _probability)
        {
            var ammo = _creator.GetOrCreateObject(_prefabAmmo, placeForSpawn).
            GetComponent<Ammo>();
            ammo.OnDeath += OnDestroyAmmo;
            _ammoes.Add(ammo);
        }
    }

    private void OnDestroyHealth()
    {
        for (int i = 0; i < _healths.Count; i++)
        {
            if (!_healths[i].isActiveAndEnabled)
            {
                _creator.DestroyObject(_prefabHealth, _healths[i].gameObject);
            }
        } 
    }

    private void OnDestroyAmmo()
    {
        for (int i = 0; i < _ammoes.Count; i++)
        {
            if (!_ammoes[i].isActiveAndEnabled)
            {
                _creator.DestroyObject(_prefabAmmo, _ammoes[i].gameObject);
            }
        }
    }

    private void OnDestroyMoney()
    {
        for (int i = 0; i < _money.Count; i++)
        {
            if (!_money[i].isActiveAndEnabled)
            {
                _creator.DestroyObject(_prefabMoney, _money[i].gameObject);
            }
        }
    }
}

