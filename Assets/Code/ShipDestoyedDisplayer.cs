using System;
using UnityEngine;

namespace Asteroids
{
    public sealed class ShipDestroyedDisplayer
    {
        private const string Message = "Корабль {0} уничтожен";

        public ShipDestroyedDisplayer()
        {}

        public void AddShip(EnemyShip ship)
        {
            ship.ShipDestroyed += Display;
        }

        public void RemoveShip(EnemyShip ship)
        {
            ship.ShipDestroyed -= Display;
        }

        public void Display(EnemyShip ship)
        {
            Debug.Log(String.Format(Message, ship.ShipName));
            RemoveShip(ship);
        }
    }
}
