using UnityEngine;

namespace Assets.Scripts
{
    public sealed class GunsList : IGunsList
    {
        public Riffle Riffle;
        public Bazooka Bazooka;
        public Grenades Grenade;
        public Mines Mine;
        public Gun CurrentGun { get; private set; }

        private IController _controller;

        private int _currentState;

        public GunsList(IController controller, Riffle riffle)
        {
            Riffle = riffle;
            _controller = controller;
            CurrentGun = Riffle;
            Riffle.SetControllerForGun(controller);
        }

        public void Fire(Transform gameObject, bool isAttack)
        {
            if (isAttack)
            {
                CurrentGun.SetNearTarger(gameObject, isAttack);
                CurrentGun.Shot();
            }
            
        }

        public void Reloading()
        {
            CurrentGun.HandleReloading();
        }

        public void ChooseWeapon()
        {
            _currentState = _controller.AxisChoose();

            if (_currentState == 1 && Riffle.IsActive)
            {
                CurrentGun = Riffle;
            }

            if (_currentState == 2 && Bazooka.IsActive)
            {
                CurrentGun = Bazooka;
            }

            if (_currentState == 3 && Grenade.IsActive)
            {
                CurrentGun = Grenade;
            }

            if (_currentState == 4 && Mine.IsActive)
            {
                CurrentGun = Mine;
            }
        }
    }
}
