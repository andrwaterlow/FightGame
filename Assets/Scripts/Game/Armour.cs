using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public sealed class Armour
    {
        private float _maxArmour;
        public float _currentArmour { get; set; }

        public Armour(float maxArmour, float currentArmour)
        {
            _maxArmour = maxArmour;
            _currentArmour = currentArmour;
        }
    }
}
