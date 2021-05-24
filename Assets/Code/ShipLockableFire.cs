namespace Asteroids
{
    public sealed class ShipLockableFire : IShipFire
    {
        private IShipFire shipFire;
        private FireLock fireLock;

        public ShipLockableFire(IShipFire _shipFire, FireLock _fireLock)
        {
            shipFire = _shipFire;
            fireLock = _fireLock;
        }

        public void Fire()
        {
            if(!fireLock.IsLocked)
                shipFire.Fire();
        }
    }
}
