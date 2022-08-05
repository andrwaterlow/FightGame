using System.Collections.Generic;
using UnityEngine;

public interface IPoolObject
{  
    public Stack<GameObject> _stack { get; set; }
    public GameObject Pop(Transform startPosition);
}