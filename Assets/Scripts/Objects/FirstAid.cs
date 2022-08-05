using System;
using UnityEngine;

public class FirstAid : MonoBehaviour
{
    [SerializeField] private int _getHp = 25;
    public event Action OnDeath;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out var player))
        {
            player.ItemManager.HealthUp(_getHp);
            Death();
            OnDeath.Invoke();
        }
    }

    private void Death()
    {
        gameObject.SetActive(false);
    }
}
