using System;

namespace Asteroids
{
    public sealed class ShipHealth : IShipHealth
    {
        public float Health { get; private set; }
        public event Action DestroyedEvent;

        public ShipHealth(float maxHealth)
        {
            Health = maxHealth;
        }

        public void Damage(float damage)
        {
            Health -= damage;
            if(Health <= 0)
            {
                Health = 0.0f;
                DestroyedEvent?.Invoke();
            }
        }
    }
}
