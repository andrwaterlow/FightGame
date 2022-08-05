using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public  class ObjectPool : IPoolObject
{
    public Stack<GameObject> _stack { get; set; } = new Stack<GameObject>();
    private readonly GameObject _prefab;

    public ObjectPool(GameObject prefab)
    {
        _prefab = prefab;
    }

    public void Push(GameObject gameObject)
    {
        _stack.Push(gameObject);
        gameObject.SetActive(false);
    }

    public GameObject Pop(Transform startPosition)
    {
        GameObject gameObject;
        if (_stack.Count == 0)
        {
            gameObject = Object.Instantiate(_prefab,
                startPosition.position, startPosition.rotation);
        }
        else
        {
            gameObject = _stack.Pop();
            gameObject.transform.position = startPosition.position;
            gameObject.transform.rotation = startPosition.rotation;
            gameObject.SetActive(true);

            if (gameObject.TryGetComponent<Enemy>(out var enemy))
            {
                gameObject.GetComponent<Enemy>().ActiveAllComponents();
                gameObject.GetComponent<Enemy>().RecoverEnemy();
                gameObject.GetComponent<Enemy>().MakeDamage(0);
            }
        }

        return gameObject;
    }
}

