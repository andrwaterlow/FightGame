using System.Collections.Generic;
using UnityEngine;

public class ViewServices
{
    public Dictionary<int, ObjectPool> _listOfPools { get; set; } =
           new Dictionary<int, ObjectPool>();

    public GameObject Create(GameObject prefab, Transform startPosition)
    {
        if (!_listOfPools.TryGetValue(prefab.GetInstanceID(), out ObjectPool viewPool))
        {
            viewPool = new ObjectPool(prefab);
            _listOfPools[prefab.GetInstanceID()] = viewPool;
        }
       return viewPool.Pop(startPosition);
    }

    public void Destroy(GameObject prefab, GameObject gameObject)
    {
        _listOfPools[prefab.GetInstanceID()].Push(gameObject);
    }
}
