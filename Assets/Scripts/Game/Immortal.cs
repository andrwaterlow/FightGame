using System.Collections;
using UnityEngine;

public class Immortal : MonoBehaviour
{
    private int _currentAmmoInGun = 1000;
    private float _delay = 0.1f;
    private float _timeOfRamage = 45f;
    private float _speed = 20;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out var player))
        {
            StartCoroutine(StartRampage(player));
        }
    }

    private IEnumerator StartRampage(Player player) 
    {
        player.ItemManager.UseRampage(_currentAmmoInGun, _delay, _speed);
        gameObject.GetComponent<BoxCollider>().enabled = false;
        gameObject.transform.position = new Vector3(0,-100,0);
        yield return new WaitForSeconds(_timeOfRamage);
        player.ItemManager.UseRampage(_currentAmmoInGun, _delay, _speed);
        gameObject.SetActive(false);
    }
}
