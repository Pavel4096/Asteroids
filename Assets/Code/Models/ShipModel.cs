namespace Asteroids
{
    public sealed class ShipModel
    {
        public float speed;
        public float maxHealth;

        public ShipModel() : this(25.0f, 1000.0f)
        {
        }

        public ShipModel(float speed_, float maxHealth_)
        {
            speed = speed_;
            maxHealth = maxHealth_;
        }
    }
}
