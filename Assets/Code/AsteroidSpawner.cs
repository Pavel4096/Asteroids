namespace Asteroids
{
    public sealed class AsteroidSpawner
    {
        private const int period = 5;
        private const uint maxAsteroidCount = 5;

        private AsteroidFactory asteroidFactory;
        private uint asteroidCount;
        private uint frameCount;

        public AsteroidSpawner(Game gameView)
        {
            asteroidFactory = new AsteroidFactory(gameView);
            asteroidFactory.AddModel(new AsteroidModel());
            asteroidFactory.AddModel(new AsteroidModel("Asteroid2"));
            asteroidCount = 0;
            frameCount = 0;
        }

        public void GameLoop(float frameTime)
        {
            frameCount++;
            if(frameCount % period == 0)
            {
                while(asteroidCount < maxAsteroidCount)
                {
                    SpawnAsteroid();
                }
            }
        }

        public void SpawnAsteroid()
        {
            asteroidFactory.GetAsteroid();
            asteroidCount++;
        }
    }
}
