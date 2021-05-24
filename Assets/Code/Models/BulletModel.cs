namespace Asteroids
{
    public sealed class BulletModel
    {
        public float MoveForce { get; set; }
        public float Damage { get; set; }
        public string Name { get; }

        const float defaultMoveForce = 10.0f;
        const float defaultDamage = 250.0f;
        const string defaultName = "Bullet";

        public BulletModel() : this(defaultMoveForce, defaultDamage, defaultName)
        {
        }

        public BulletModel(float _moveForce, float _damage, string _name)
        {
            MoveForce = _moveForce;
            Damage = _damage;
            Name = _name;
        }
    }
}
