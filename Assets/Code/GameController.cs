using System;

namespace Asteroids
{
    public sealed class GameController : IGameController
    {
        public event Action<float> GameLoop;

        private Game gameView;
        private IPlayerController playerController;

        private AsteroidFactory asteroidFactory;

        public GameController(Game gameView_)
        {
            gameView = gameView_;
        }

        public void Init()
        {
            playerController = ShipController.GetShip(gameView, new ShipModel());

            SpawnAsteroids();
        }

        public void UpdateGame(UserInput userInput, float frameTime)
        {
            playerController?.ProcessInput(userInput, frameTime);
            GameLoop?.Invoke(frameTime);
        }

        private void SpawnAsteroids()
        {
            asteroidFactory = new AsteroidFactory(gameView);
            AsteroidModel model = new AsteroidModel();
            AsteroidModel model2 = new AsteroidModel("Asteroid2");
            asteroidFactory.AddModel(model);
            asteroidFactory.AddModel(model2);
            for(int i = 0; i < 5; i++)
                asteroidFactory.GetAsteroid();
        }
    }
}
