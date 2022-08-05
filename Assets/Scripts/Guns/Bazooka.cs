using UnityEngine;

namespace Assets.Scripts
{
    public sealed class Bazooka : Gun
    {
        private GameObject _bazookaPrefab;
        private GameObject _missilePrefab;

        private float _powerOfExplosion = 50;
        private float _distance = 5;
        private float _longOfShot = 1000;

        public void Awake()
        {
            IsActive = true;
            Delay = false;
            TimeDelay = 0.1f;
            Damage = 100;
            TimeReloading = 8;
            MaxAmmo = 5;
            MaxAmmoInGun = 1;
            CurrentAmmoInGun = Mathf.Clamp(MaxAmmoInGun, 0, MaxAmmoInGun);
            CurrentAmmo = Mathf.Clamp(MaxAmmo, 0, MaxAmmo);
            _missilePrefab = Resources.Load<GameObject>("Missile");
            _bazookaPrefab = Resources.Load<GameObject>("Bazooka");
        }

        protected override void SpecificGunShot()
        {
            var bullet = Instantiate(_missilePrefab, StartPosition.position,
                transform.rotation).GetComponent<Missile>();
            bullet.InitializeMissle(Damage, _powerOfExplosion, _distance, _explodable);

            var rigidBody = bullet.GetComponent<Rigidbody>();

            rigidBody.AddForce(StartPosition.forward * _longOfShot, ForceMode.Impulse);
        }
    }
}
