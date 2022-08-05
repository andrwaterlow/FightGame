using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerForPlayer : MonoBehaviour
{
    private bool _playerOrPlace;

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<Player>(out var player))
        {
            PlayerOnPlace();
            Debug.Log("da");
        }
    }

    private void PlayerOnPlace()
    {
        _playerOrPlace = true;
    }

    public bool PlayerOnPlaceOrNot()
    {
        return _playerOrPlace;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Player>(out var player))
        {
            _playerOrPlace = false;
            Debug.Log("net");
        }
    }
}
