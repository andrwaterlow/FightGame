namespace Assets.Scripts
{
    public sealed class Health
    {
        private float _maxHealth;
        public float  _currentHealth { get; set; }

        public Health(float maxHealth, float currentHealth)
        {
            _maxHealth = maxHealth;
            _currentHealth = currentHealth;
        }
    }
}
