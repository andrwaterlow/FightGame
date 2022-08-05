using UnityEngine;

namespace Assets.Scripts
{
    public sealed class Damage : ITakeDamage
    {
        private Health _health;
        private Armour _armour;

        public Damage(Health health, Armour armour)
        {
            _health = health;
            _armour = armour;
        }

        public void TakeDamage(float damage)
        {
            float denominatorForDamage = Random.Range(1f, 2f);

            if (_armour._currentArmour > 0)
            {
                var realDamage = damage - ((damage / 100) * _armour._currentArmour);
                _health._currentHealth -= realDamage;
                Debug.Log(realDamage + "real dam");
                _armour._currentArmour -= (damage / denominatorForDamage);

                if (_armour._currentArmour < 0)
                {
                    _armour._currentArmour = 0;
                }
            }
            else
            { 
                _health._currentHealth -= damage;
                Debug.Log(_health._currentHealth);
            }
        }

        public bool CheckLiveStatus()
        {
            if (_health._currentHealth <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
