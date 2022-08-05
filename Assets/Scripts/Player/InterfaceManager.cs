namespace Assets.Scripts
{
    public sealed class InterfaceManager : IInterfaceManager
    {
        private Health _health;
        private Armour _armour;
        private GunsList _gunsList;
        private Money _money;
        private CounterItems _counterItems;      

        public InterfaceManager(Health health, Armour armour, GunsList gunsList, Money money,
            CounterItems counterItems)
        {
            _health = health;
            _armour = armour;
            _gunsList = gunsList;
            _money = money;
            _counterItems = counterItems;
        }

        public (int curbull, int gunbull) Ammo()
        {
            int curbull = _gunsList.CurrentGun.CurrentAmmo;
            int gunbull = _gunsList.CurrentGun.CurrentAmmoInGun;
            return (curbull, gunbull);
        }

        public float HP()
        {
            return _health._currentHealth;
        }

        public float Armour()
        {
            return _armour._currentArmour;
        }

        public int Money()
        {
            return _money.GetMoney();
        }

        public int Items()
        {
            return _counterItems.GetCountItems();
        }
    }
}
