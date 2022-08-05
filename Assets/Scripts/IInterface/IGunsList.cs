using UnityEngine;

namespace Assets.Scripts
{
    public interface IGunsList
    {
        public Gun CurrentGun { get; }
        public void Fire(Transform gameObject, bool isAttack);
        public void Reloading();
        public void ChooseWeapon();
    }
}