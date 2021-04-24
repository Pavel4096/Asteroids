using UnityEngine;

namespace Asteroids
{
    public sealed class ShipCollided : IShipCollided
    {
        private IView shipView;
        private IShipHealth shipHealth;

        public ShipCollided(IView shipView_, IShipHealth shipHealth_)
        {
            shipView = shipView_;
            shipHealth = shipHealth_;
            shipView.CollidedEvent += Collided;
        }

        public void Dispose()
        {
            shipView.CollidedEvent -= Collided;
        }

        private void Collided(Collision2D collision)
        {
            shipHealth.Damage(500);
        }
    }
}
