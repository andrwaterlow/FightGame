using System;
using UnityEngine;

public class TriggerBase : MonoBehaviour
{
    public event Action OnBase;

    private bool _enterIn;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out var player))
        {
            if (_enterIn)
            {
                OnBase.Invoke();
                _enterIn = false;
            } 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _enterIn = true;
    }
}
