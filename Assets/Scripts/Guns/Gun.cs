using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public abstract class Gun : MonoBehaviour
    {
        protected IController _controller;
        protected IExplodable _explodable;

        public bool IsActive { get;protected set; }
        public bool Delay { get; protected set; }
        public bool IsEnemy { get; protected set; }
        public float TimeDelay { get; protected set; }
        public float Damage { get; protected set; }
        public float TimeReloading { get; protected set; }
        public int MaxAmmo { get; protected set; }
        public int MaxAmmoInGun { get; protected set; }
        public int CurrentAmmoInGun { get; protected set; }
        public int CurrentAmmo { get; protected set; }
        public Transform StartPosition { get; protected set; }
        public Transform Target { get; protected set; }
        public bool IsAttacking { get; set; }
        private bool Reloading;

        private void Start()
        {
            _explodable = new Explodable();
            IsEnemy = CheckControlerForIndentify();
        }

        public void SetControllerForGun(IController controller)
        {
            _controller = controller;
            IsEnemy = CheckControlerForIndentify();
        }

        private bool CheckControlerForIndentify()
        {
            if (_controller == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SetStartPositionAndCenterScreen(Transform startPosition)
        {
            StartPosition = startPosition;
        }

        public  void Shot()
        {
            if (IsEnemy || CurrentAmmoInGun > 0 && !Delay && !Reloading)
            {
                SpecificGunShot();
                CurrentAmmoInGun -= 1;
                StartCoroutine(GunDelay());
            }
            if (CurrentAmmoInGun == 0 && IsActive && !Reloading)
            {
                Debug.Log("StartReload");
                StartCoroutine(AutoReloading());
            }
        }

        private IEnumerator GunDelay()
        {
            Delay = true;
            yield return new WaitForSeconds(TimeDelay);
            Delay = false;
        }

        protected abstract void SpecificGunShot();

        public void HandleReloading()
        {
            if (_controller.AxisReload() && !Reloading)
            {
                Reloading = true;
                StartCoroutine(StartReloding());
            }
        }

        private IEnumerator StartReloding()
        {
            if (CurrentAmmo > 0)
            {
                yield return new WaitForSeconds(TimeReloading);
                var lostAmmo = MaxAmmoInGun - CurrentAmmoInGun;
                CurrentAmmo -= lostAmmo;
                CurrentAmmoInGun = MaxAmmoInGun;
                Reloading = false;
            }
        }

        private IEnumerator AutoReloading()
        {
            Reloading = true;
            if (CurrentAmmo <= 0 && CurrentAmmoInGun <= 0)
            {    
                DeactiveGun();
                Reloading = false;
                yield break;
            }

            if (CurrentAmmo > 0 )
            {
                yield return new WaitForSeconds(TimeReloading);
                var lostAmmo = MaxAmmoInGun - CurrentAmmoInGun;
                CurrentAmmo -= lostAmmo;
                CurrentAmmoInGun = MaxAmmoInGun;
                Debug.Log("ReloadComplete");
                Reloading = false;
            }
        }

        public void ActiveGun()
        {
            IsActive = true;
        }

        private void DeactiveGun()
        {
            IsActive = false;
        }

        public void AmmoUp(int PlusAmmo)
        {
            CurrentAmmo += PlusAmmo;
        }

        public void RampageAmmo(int rampageCurrentAmmoInGun)
        {
            CurrentAmmoInGun = rampageCurrentAmmoInGun;
        }

        public void RampageDelay(float rampageDelay)
        {
            TimeDelay = rampageDelay;
        }

        public (int, float) StartStats()
        {
            var startCurrentAmmoInGun = CurrentAmmoInGun;
            var startDelay = TimeDelay;
            return (startCurrentAmmoInGun, startDelay);
        }

        public void ReturnStartStats(int StartCurrentAmmoInGun, float StartrampageDelay)
        {
            CurrentAmmoInGun = StartCurrentAmmoInGun;
            TimeDelay = StartrampageDelay;

        }

        public void SetNearTarger(Transform nearObject, bool isAttacking )
        {
            if (nearObject == null)
            {
                return;
            }

            Target = nearObject.transform;
            IsAttacking = isAttacking;
        }
    }   

}