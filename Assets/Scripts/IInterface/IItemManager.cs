using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public interface IItemManager
    {
        public void HealthUp(float plusHP);
        public void ArmourUp(float plusArmour);
        public void AmmoForRiffleUp(int plusAmmo);
        public void AmmoForBazookaUp(int plusAmmo);
        public void AmmoForGrenadeUp(int plusAmmo);
        public void AmmoForMineUp(int plusAmmo);
        public void UseRampage(int rampageCurrentAmmoInGun, float rampageDelay, float rampageSpeed);
        public void MoneyUp(Banknotes money);
    }
}
