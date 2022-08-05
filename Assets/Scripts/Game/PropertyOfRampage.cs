namespace Assets.Scripts
{
    public sealed class PropertyOfRampage
    {
        private Health _health;
        private Armour _armour;
        private GunsList _gunsList;
        private Movement _movement;

        public int BazookaCurrentAmmoInGun { get; private set; }
        public float BazookaDelay { get; private set; }
        public int GrenadeCurrentAmmoInGun { get; private set; }
        public float GrenadeDelay { get; private set; }
        public int MineCurrentAmmoInGun { get; private set; }
        public float MineDelay { get; private set; }
        public int RiffleCurrentAmmoInGun { get; private set; }
        public float RiffleDelay { get; private set; }
        public float CurrentHealth { get; private set; }
        public float CurrentArmour { get; private set; }
        public float CurrentPlayerSpeed { get; private set; }

        public bool RampageUsed { get; private set; } = false;

        public PropertyOfRampage(Health health, Armour armour, GunsList gunsList, Movement movement)
        {
            _health = health;
            _armour = armour;
            _gunsList = gunsList;
            _movement = movement;
        }

        public void ActiveOrDeactiveRampage(int rampageCurrentAmmoInGun, float rampageDelay, float rampageSpeed)
        {
            SaveOrReturnStartStats();
            if (!RampageUsed)
            {
                _gunsList.Bazooka.RampageAmmo(rampageCurrentAmmoInGun);
                _gunsList.Bazooka.RampageDelay(rampageDelay);
                _gunsList.Grenade.RampageAmmo(rampageCurrentAmmoInGun);
                _gunsList.Grenade.RampageDelay(rampageDelay);
                _gunsList.Mine.RampageAmmo(rampageCurrentAmmoInGun);
                _gunsList.Mine.RampageDelay(rampageDelay);
                _gunsList.Riffle.RampageAmmo(rampageCurrentAmmoInGun);
                _gunsList.Riffle.RampageDelay(rampageDelay);
                _health._currentHealth = 9999;
                _armour._currentArmour = 1000;
                _movement.SetNewSpeed(rampageSpeed);
                RampageUsed = true;
                return;
            }
            if (RampageUsed)
            {
                RampageUsed = false;
            }
        }

        private void SaveOrReturnStartStats()
        {
            if (!RampageUsed)
            {
                (BazookaCurrentAmmoInGun, BazookaDelay) = _gunsList.Bazooka.StartStats();
                (GrenadeCurrentAmmoInGun, GrenadeDelay) = _gunsList.Grenade.StartStats();
                (MineCurrentAmmoInGun, MineDelay) = _gunsList.Mine.StartStats();
                (RiffleCurrentAmmoInGun, RiffleDelay) = _gunsList.Riffle.StartStats();
                CurrentPlayerSpeed = _movement._movingSpeed;
            }
            else
            {
                _gunsList.Bazooka.ReturnStartStats(BazookaCurrentAmmoInGun, BazookaDelay);
                _gunsList.Grenade.ReturnStartStats(GrenadeCurrentAmmoInGun, GrenadeDelay);
                _gunsList.Mine.ReturnStartStats(MineCurrentAmmoInGun, MineDelay);
                _gunsList.Riffle.ReturnStartStats(RiffleCurrentAmmoInGun, RiffleDelay);
                _health._currentHealth = 100;
                _armour._currentArmour = 100;
                _movement.SetNewSpeed(CurrentPlayerSpeed);
            }
        }
    }
}
