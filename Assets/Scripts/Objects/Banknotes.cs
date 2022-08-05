using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banknotes : MonoBehaviour
{
    public int Cost = 100;
    public event Action OnDeath;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out var player))
        {
            player.ItemManager.MoneyUp(this);
            Death();
            OnDeath.Invoke();
        }
    }

    private void Death()
    {
        gameObject.SetActive(false);
    }
}
