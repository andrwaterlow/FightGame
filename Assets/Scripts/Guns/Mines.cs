using Assets.Scripts;
using UnityEngine;

public class Mines : Gun
{
    private float _timeOfExplotion = 1.5f;
    private float _powerOfExplotion = 500f;
    private float _radiousOfExplosion = 3f;
    private float _jump = 40f;

    private GameObject _minePrefab;

    private void Awake()
    {
        IsActive = true;
        Delay = false;
        TimeDelay = 0.1f;
        Damage = 80;
        TimeReloading = 2f;
        MaxAmmo = 5;
        MaxAmmoInGun = 1;
        CurrentAmmoInGun = Mathf.Clamp(MaxAmmoInGun, 0, MaxAmmoInGun);
        CurrentAmmo = Mathf.Clamp(MaxAmmo, 0, MaxAmmo);
        _minePrefab = Resources.Load<GameObject>("Mine");
    }

    protected override void SpecificGunShot()
    {
        var mine = Instantiate(_minePrefab, StartPosition.position, Quaternion.identity);
        mine.GetComponent<Mine>().InitializeMine(Damage, _powerOfExplotion,
            _radiousOfExplosion, _explodable, _timeOfExplotion, _jump);
    }
}

    
