using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{
    private GameObject _prefabEnemy;
    private List<Enemy> _enemies;
    private Creator _creator;

    void Start()
    {
        _prefabEnemy = Resources.Load<GameObject>("Enemy");
        _enemies = new List<Enemy>();
        _creator = FindObjectOfType<Creator>();
    }

    public void SpawnEnemy(Transform placeForSpawn)
    {
        var enemy = _creator.GetOrCreateObject(_prefabEnemy, placeForSpawn).
            GetComponent<Enemy>();
        _enemies.Add(enemy);
    }

    public void DeleteAllEnemy()
    {
        for (int i = 0; i < _enemies.Count; i++)
        {
            _creator.DestroyObject(_prefabEnemy, _enemies[i].GetEnemy());
        }
        _enemies.Clear();
    }
}
