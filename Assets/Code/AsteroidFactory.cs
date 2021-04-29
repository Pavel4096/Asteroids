using System;
using System.Collections.Generic;

namespace Asteroids
{
    public sealed class AsteroidFactory : IAsteroidFactory
    {
        private Game gameView;
        private List<AsteroidModel> models = new List<AsteroidModel>();
        //private PoolManager<AsteroidModel, AsteroidController> poolManager;
        private Random rnd;

        public AsteroidFactory(Game gameView_)
        {
            gameView = gameView_;
            //poolManager = new PoolManager<AsteroidModel, AsteroidController>(CreateNewAsteroid);
            PoolLocator.Add<AsteroidModel, AsteroidController>(CreateNewAsteroid);
            rnd = new System.Random();
        }

        public void AddModel(AsteroidModel model)
        {
            if(!models.Contains(model))
                models.Add(model);
        }

        public IController GetAsteroid()
        {
            AsteroidController asteroidController;
            AsteroidModel model = models[rnd.Next(0, models.Count)];
            PoolManager<AsteroidModel, AsteroidController> poolManager = PoolLocator.Get<AsteroidModel, AsteroidController>();

            asteroidController = poolManager.GetOrCreate(model);
            asteroidController.Initialize();
            return asteroidController;
        }

        private AsteroidController CreateNewAsteroid(AsteroidModel model)
        {
            return new AsteroidController(model, gameView.CreateView(model.Name));
        }
    }
}
