using UnityEngine;

namespace Assets.Scripts
{
    public sealed class Riffle : Gun
    {
        private GameObject _rifflePrefab;
        private GameObject _bulletPrefab;
        private LineRenderer _liser;

        private void Awake()
        {
            IsActive = true;
            Delay = false;
            TimeDelay = 0.1f;
            Damage = 15;
            TimeReloading = 3;
            MaxAmmo = 250;
            MaxAmmoInGun = 300;
            CurrentAmmoInGun = Mathf.Clamp(MaxAmmoInGun, 0, MaxAmmoInGun);
            CurrentAmmo = Mathf.Clamp(MaxAmmo, 0, MaxAmmo);
            _rifflePrefab = Resources.Load<GameObject>("Riffle");
            _bulletPrefab = Resources.Load<GameObject>("Bullet");
        }

        protected override void SpecificGunShot()
        {
            if (Target.parent.GetComponent<Enemy>().isActiveAndEnabled)
            {
                var bullet = Instantiate(_bulletPrefab, StartPosition.position, Quaternion.identity).GetComponent<Bullet>();
                bullet.Initital(Damage);
                bullet.GetEnemyTransform(Target, IsAttacking);
            }    
        }
    }
}
