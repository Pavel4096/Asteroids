namespace Asteroids
{
    public sealed class ShipController : IController, IPlayerController
    {
        private ShipModel model;
        private IShipMove shipMove;

        public ShipController()
        {

        }

        public void ProcessInput(UserInput userInput, float frameTime)
        {

        }
    }
}
