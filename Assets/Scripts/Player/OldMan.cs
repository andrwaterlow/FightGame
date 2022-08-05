using UnityEngine;

namespace Assets.Scripts
{
    public sealed class OldMan : ITakeDamage, IMovement , IGunsList, IManagerWindow
    {
        private readonly ITakeDamage _takeDamageImplementation;
        private readonly IMovement _movementImplementation;
        private readonly IGunsList _gunsListImplementation;
        private readonly IManagerWindow _managerWindowImplementation;

        public Gun CurrentGun => throw new System.NotImplementedException();

        public OldMan(ITakeDamage takeDamageImplementation,
            IMovement movementImplementation, IGunsList gunsListImplementation, 
                IManagerWindow managerWindowImplementation)
        {
            _takeDamageImplementation = takeDamageImplementation;
            _movementImplementation = movementImplementation;
            _gunsListImplementation = gunsListImplementation;
            _managerWindowImplementation = managerWindowImplementation;
        }

        public void ChooseWeapon()
        {
            _gunsListImplementation.ChooseWeapon();
        }

        public void Fire(Transform gameObject, bool isAttack)
        {
            _gunsListImplementation.Fire(gameObject, isAttack);
        }

        public void Jump()
        {
            _movementImplementation.Jump();
        }

        public void LookAround()
        {
            _movementImplementation.LookAround();
        }

        public void Move()
        {
            _movementImplementation.Move();
        }   

        public void Reloading()
        {
            _gunsListImplementation.Reloading();
        }

        public void TakeDamage(float damage)
        {
            _takeDamageImplementation.TakeDamage(damage);
        }

        public bool CheckLiveStatus()
        {
            return _takeDamageImplementation.CheckLiveStatus();
        }

        public void Paused()
        {
            _managerWindowImplementation.Paused();
        }

        public bool Act()
        {
            return _movementImplementation.Act();
        }
    }
}
