using System;
using UnityEngine;

namespace Asteroids
{
    public sealed class NewShipDisplayer : INewShip
    {
        private const string NewShipString = "Корабль {0} ({1}) появился";

        public void ShowNewShip(EnemyShip ship)
        {
            Debug.Log(String.Format(NewShipString, ship.ShipName, nameof(EnemyShip)));
        }

        public void ShowNewShip(AnotherEnemyShip ship)
        {
            Debug.Log(String.Format(NewShipString, ship.ShipName, nameof(AnotherEnemyShip)));
        }
    }
}
