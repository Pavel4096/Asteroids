namespace Asteroids
{
    public sealed class ShipModel
    {
        public float MoveForce { get; }
        public float Torque { get; }
        public float MaxHealth { get; }
        public string Name { get; } = "Ship";

        public ShipModel() : this(125.0f, 75f, 1000.0f)
        {
        }

        public ShipModel(float moveForce_, float torque_, float maxHealth_)
        {
            MoveForce = moveForce_;
            Torque = torque_;
            MaxHealth = maxHealth_;
        }
    }
}
