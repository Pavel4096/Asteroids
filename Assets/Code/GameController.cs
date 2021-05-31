using System;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public sealed class GameController : IGameController
    {
        public event Action<float> GameLoop;

        private Game gameView;
        private IPlayerController playerController;

        private AsteroidFactory asteroidFactory;

        private AsteroidSpawner asteroidSpawner;

        private List<EnemyShip> ships;
        private ShipDestroyedDisplayer shipDestroyedDisplayer;

        public GameController(Game gameView_)
        {
            gameView = gameView_;
        }

        public void Init()
        {
            playerController = ShipController.GetShip(gameView, new ShipModel());
            asteroidSpawner = new AsteroidSpawner(gameView);

            Debug.Log(5.ToText());
            Debug.Log(5001.ToText());
            Debug.Log(1004000.ToText());
            Debug.Log(2600000000.ToText());

            var calculator = new Calculator();
            Debug.Log(calculator.Compute("6+2 + 10/2 + 2"));

            if(playerController is IShipController ship)
            {
                var modifiers = new ShipModifier(ship);
                modifiers.Add(new ShipHPModifier(ship, 500));
                modifiers.Add(new ShipArmourModifier(ship, 250));
                modifiers.Handle();
            }

            ships = new List<EnemyShip>();
            shipDestroyedDisplayer = new ShipDestroyedDisplayer();
            var newShipDisplayer = new NewShipDisplayer();
            var rnd = new System.Random();
            for(int i = 0; i < 10; i++)
            {
                //EnemyShip currentShip = new EnemyShip();
                EnemyShip currentShip;
                if(rnd.Next(0,2) == 0)
                    currentShip = new EnemyShip();
                else
                    currentShip = new AnotherEnemyShip();
                
                currentShip.Init(newShipDisplayer);
                shipDestroyedDisplayer.AddShip(currentShip);
                ships.Add(currentShip);
            }

            for(int i = 0; i < 1000; i++)
            {
                int index = rnd.Next(0, ships.Count);
                ships[index].Damage(100);
            }
        }

        public void UpdateGame(UserInput userInput, float frameTime)
        {
            asteroidSpawner.GameLoop(frameTime);
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
