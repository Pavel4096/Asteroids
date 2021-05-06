namespace Parsing
{
    public sealed class InfantryUnit : IUnit
    {
        private float health;

        public InfantryUnit(float _health)
        {
            health = _health;
        }
    }
}
