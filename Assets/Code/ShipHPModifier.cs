namespace Asteroids
{
    public sealed class ShipHPModifier : ShipModifier
    {
        private float hp;

        public ShipHPModifier(IShipController _ship, float _hp) : base(_ship)
        {
            hp = _hp;
        }

        public override void Handle()
        {
            ship.AddHP(hp);
            base.Handle();
        }
    }
}
