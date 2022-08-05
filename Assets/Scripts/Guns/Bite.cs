using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bite : Gun
{
    private GameObject _gameObject;

    private void Start()
    {
        IsActive = true;
        TimeDelay = 0.7f;
        Damage = 4f;
        TimeReloading = 0.001f;
        MaxAmmo = 9999999;
        MaxAmmoInGun = 9999999;
        CurrentAmmoInGun = 9999999;
        CurrentAmmo = 9999999;
    }

    protected override void SpecificGunShot()
    {
        Debug.Log("ggg");
        Player player = _gameObject.GetComponent<Player>();
        player.MakeDamage(Damage);
        player.GetComponent<CharacterController>().Move(-gameObject.transform.forward);

    }

    private void OnTriggerEnter(Collider other)
    {           
        if (other.TryGetComponent<Player>(out var player))
        {
            _gameObject = player.gameObject;
            SpecificGunShot();
        }
    }

  /*  private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<Player>(out var player))
        {
            _gameObject = player.gameObject;
            SpecificGunShot();
        }
    }*/
}
