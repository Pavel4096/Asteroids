namespace Asteroids
{
    public sealed class ShipController : IPlayerController
    {
        private ShipModel model;
        private IView view;
        private IShipMove shipMove;
        private IShipRotate shipRotate;
        private IShipCollided shipCollided;
        private IShipHealth shipHealth;

        public ShipController(ShipModel model_, IView view_, IShipMove shipMove_, IShipRotate shipRotate_, IShipCollided shipCollided_, IShipHealth shipHealth_)
        {
            model = model_;
            view = view_;
            shipMove = shipMove_;
            shipRotate = shipRotate_;
            shipCollided = shipCollided_;
            shipHealth = shipHealth_;
            shipHealth.DestroyedEvent += ShipDestroyed;
        }

        public void ProcessInput(UserInput userInput, float frameTime)
        {
            shipMove.Move(userInput.Vertical, frameTime);
            shipRotate.Rotate(userInput.Horizontal, frameTime);
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
