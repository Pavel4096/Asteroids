namespace Asteroids
{
    public sealed class AnotherEnemyShip : EnemyShip
    {
        public override void Init(INewShip newShipDisplayer)
        {
            newShipDisplayer.ShowNewShip(this);
        }
    }
}
