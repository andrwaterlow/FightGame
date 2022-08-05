using System.Collections.Generic;

namespace Assets.Scripts
{
    public sealed class ItemManager : IItemManager
    {
        private Health _health;
        private Armour _armour;
        private GunsList _gunsList;
        private PropertyOfRampage _propertyOfRampage;
        private Money _money;
        private TriggerBase _triggerBase;
        private List<Banknotes> _listMoney;
        private CounterItems _counterItems;

        public ItemManager(Health health, Armour armour, GunsList gunsList,
            PropertyOfRampage propertyOfRampage, Money money, TriggerBase triggerBase,
                CounterItems counterItems)
        {
            _health = health;
            _armour = armour;
            _gunsList = gunsList;
            _propertyOfRampage = propertyOfRampage;
            _money = money;
            _listMoney = new List<Banknotes>();
            _triggerBase = triggerBase;
            _triggerBase.OnBase += CalculateMoney;
            _counterItems = counterItems;
        }

        public void HealthUp(float plusHP)
        {
            _health._currentHealth += plusHP;
            CalculateCountItems();
        }

        public void ArmourUp(float plusArmour)
        {
            _armour._currentArmour += plusArmour;
        }

        public void AmmoForRiffleUp(int plusAmmo)
        {
            _gunsList.Riffle.AmmoUp(plusAmmo);
            CalculateCountItems();
        }

        public void AmmoForBazookaUp(int plusAmmo)
        {
            _gunsList.Bazooka.AmmoUp(plusAmmo);
        }

        public void AmmoForGrenadeUp(int plusAmmo)
        {
            _gunsList.Grenade.AmmoUp(plusAmmo);
        }

        public void AmmoForMineUp(int plusAmmo)
        {
            _gunsList.Mine.AmmoUp(plusAmmo);
        }

        public void UseRampage(int rampageCurrentAmmoInGun, float rampageDelay, float rampageSpeed)
        {
            _propertyOfRampage.ActiveOrDeactiveRampage(rampageCurrentAmmoInGun, rampageDelay, rampageSpeed);
        }

        public void MoneyUp(Banknotes money)
        {
            _listMoney.Add(money);
            CalculateCountItems();
        }

        public void CalculateMoney()
        {
            for (int i = 0; i < _listMoney.Count; i++)
            {
                _money.MoneyUp(_listMoney[i].Cost);
            }
            _listMoney.Clear();
            _counterItems.CalculateAllItems();
        }

        public void CalculateCountItems()
        {
            _counterItems.CalculateOneItem();
        }
    }
}
