namespace Asteroids
{
    public sealed class ShipController : IPlayerController, IShipController
    {
        private ShipModel model;
        private IView view;
        private IShipMove shipMove;
        private IShipRotate shipRotate;
        private IShipCollided shipCollided;
        private IShipHealth shipHealth;
        private IShipFire shipFire;
        private FireLock fireLock;

        private const float initial_hp = 1000.0f;
        private const float initial_armour = 0.0f;

        public float hp;
        public float armour;

        public ShipController(ShipModel model_, IView view_, IShipMove shipMove_, IShipRotate shipRotate_, IShipCollided shipCollided_, IShipHealth shipHealth_, IShipFire _shipFire, FireLock _fireLock)
        {
            model = model_;
            view = view_;
            shipMove = shipMove_;
            shipRotate = shipRotate_;
            shipCollided = shipCollided_;
            shipHealth = shipHealth_;
            shipHealth.DestroyedEvent += ShipDestroyed;
            shipFire = _shipFire;
            fireLock = _fireLock;

            hp = initial_hp;
            armour = initial_armour;
        }

        public static ShipController GetShip(Game gameView, ShipModel shipModel)
        {
            IView shipView = gameView.CreateView(shipModel.Name);
            IShipMove shipMove = new ShipMove(shipView.Rigidbody2D, shipModel.MoveForce);
            IShipRotate shipRotate = new ShipRotate(shipView.Rigidbody2D, shipModel.Torque);
            IShipHealth shipHealth = new ShipHealth(shipModel.MaxHealth);
            IShipCollided shipCollided = new ShipCollided(shipView, shipHealth);
            IShipFire shipFire = new ShipFire();
            FireLock fireLock = new FireLock();
            IShipFire shipLockableFire = new ShipLockableFire(shipFire, fireLock);

            return new ShipController(shipModel, shipView, shipMove, shipRotate, shipCollided, shipHealth, shipLockableFire, fireLock);
        }

        public void ProcessInput(UserInput userInput, float frameTime)
        {
            shipMove.Move(userInput.Vertical, frameTime);
            shipRotate.Rotate(userInput.Horizontal, frameTime);
        }

        public void AddHP(float _hp)
        {
            hp += _hp;
        }

        public void AddArmour(float _armour)
        {
            armour += _armour;
        }

        public void ShipDestroyed()
        {
        }

        public void Dispose()
        {
            shipHealth.DestroyedEvent -= ShipDestroyed;
            shipCollided.Dispose();
        }
    }
}
