using UnityEngine;

namespace Asteroids
{
    public sealed class ShipRotate : IShipRotate
    {
        private Rigidbody2D rigidbody2d;
        private float torque;

        public ShipRotate(Rigidbody2D rigidbody2d_, float torque_)
        {
            rigidbody2d = rigidbody2d_;
            torque = torque_;
        }

        public void Rotate(float horizontal, float frameTime)
        {
            rigidbody2d.AddTorque(-torque*frameTime*horizontal);
        }
    }
}
