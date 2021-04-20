namespace Asteroids
{
    public sealed class ShipInitializer
    {
        public ShipController ShipController { get; }

        public ShipInitializer(Game gameView)
        {
            ShipModel shipModel = new ShipModel();
            IView shipView = gameView.CreateView(shipModel.Name);
            IShipMove shipMove = new ShipMove(shipView.Rigidbody2D, shipModel.MoveForce);
            IShipRotate shipRotate = new ShipRotate(shipView.Rigidbody2D, shipModel.Torque);
            IShipHealth shipHealth = new ShipHealth(shipModel.MaxHealth);
            IShipCollided shipCollided = new ShipCollided(shipView, shipHealth);
            ShipController = new ShipController(shipModel, shipView, shipMove, shipRotate, shipCollided, shipHealth);
        }
    }
}
