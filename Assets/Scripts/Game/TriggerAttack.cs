using System;
using UnityEngine;

public class TriggerAttack : MonoBehaviour
{
    private Transform _playerPosition;
    private bool _onTrigger;

    public event Action PlayerLost;

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<Player>(out var player))
        {
            if (player.IsAlive)
            {
                SetPositionsOfPlayer(player);
                ActiveTrigger();
            }
            else
            {
                DeactiveTrigger();
                PlayerLost.Invoke();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Player>(out var player))
        {
            DeactiveTrigger();
            PlayerLost.Invoke();
        }
    }

    private void ActiveTrigger()
    {
        _onTrigger = true;
    }

    private void DeactiveTrigger()
    {
        _onTrigger = false;
    }

    private void SetPositionsOfPlayer(Player player)
    {
        _playerPosition = player.transform;
    }

    public Transform GetPlayerPosition()
    {
        return _playerPosition;
    }

    public bool PlayerOnTriggerOrNot()
    {
        return _onTrigger;
    }
}
