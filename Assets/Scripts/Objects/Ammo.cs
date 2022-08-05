using System;
using UnityEngine;
using UnityEngine.Events;

public class Ammo : MonoBehaviour
{
    [SerializeField] private int _getAmmo = 30;
    public  event Action OnDeath;


    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out var player))
        {
            player.ItemManager.AmmoForRiffleUp(_getAmmo);
            Death();
            OnDeath.Invoke();
        }
    }

    private void Death()
    {
        gameObject.SetActive(false);
    }
}
