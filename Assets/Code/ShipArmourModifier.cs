namespace Asteroids
{
    public sealed class ShipArmourModifier : ShipModifier
    {
        private float armour;

        public ShipArmourModifier(IShipController _ship, float _armour) : base(_ship)
        {
            armour = _armour;
        }

        public override void Handle()
        {
            ship.AddArmour(armour);
            base.Handle();
        }
    }
}
