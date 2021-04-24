using System;

namespace Asteroids
{
    public interface IShipHealth
    {
        void Damage(float damage);
        event Action DestroyedEvent;
    }
}
