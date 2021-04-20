using UnityEngine;

namespace Asteroids
{
    public class ShipMove : IShipMove
    {
        private Rigidbody2D rigidbody2d;
        private float moveForce;

        public ShipMove(Rigidbody2D rigidbody2d_, float moveForce_)
        {
            rigidbody2d = rigidbody2d_;
            moveForce = moveForce_;
        }

        public void Move(float vertical, float frameTime)
        {
            rigidbody2d.AddRelativeForce(Vector2.up*moveForce*frameTime*vertical);
        }
    }
}
