using Assets.Scripts;
using UnityEngine;

public class Grenades : Gun
{
    private float _timeOfExplotion = 3;
    private float _powerOfExplotion = 50f;
    private float _radiousOfExplosion = 3f;
    private float _longOfShotForGrenade = 750f;

    private GameObject _GrenadePrefab;
    private GameObject _cloneGrenade;

    private AudioSource _audioSource;

    private void Awake()
    {
        IsActive = true;
        Delay = false;
        TimeDelay = 0.1f;
        Damage = 80;
        TimeReloading = 3;
        MaxAmmo = 5;
        MaxAmmoInGun = 1;
        CurrentAmmoInGun = Mathf.Clamp(MaxAmmoInGun, 0, MaxAmmoInGun);
        CurrentAmmo = Mathf.Clamp(MaxAmmo, 0, MaxAmmo);
        _GrenadePrefab = Resources.Load<GameObject>("Grenade");
    }

    protected override void SpecificGunShot()
    {
        _cloneGrenade = Instantiate(_GrenadePrefab, StartPosition.position,
            StartPosition.rotation);
        var rigidBodyGrenade = _cloneGrenade.GetComponent<Rigidbody>();

        rigidBodyGrenade.AddForce(StartPosition.forward * _longOfShotForGrenade);
        rigidBodyGrenade.AddTorque(Random.insideUnitSphere * _longOfShotForGrenade);

        var grenade = _cloneGrenade.GetComponent<Grenade>();
        grenade.InitializeGrenade(Damage, _powerOfExplotion, _radiousOfExplosion, _explodable, _timeOfExplotion); 
    }
}
