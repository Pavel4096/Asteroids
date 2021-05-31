using System;

namespace Asteroids
{
    public class EnemyShip
    {
        public event Action<EnemyShip> ShipDestroyed;

        public string ShipName
        {
            get => shipName;
        }

        private float hp;
        private string shipName;

        private const float initialHP = 1000;
        private const string ShipNameString = "Ship{0}";

        private static int number = 0;

        public EnemyShip()
        {
            hp = initialHP;
            shipName = String.Format(ShipNameString, EnemyShip.number++);
            ShipDestroyed += delegate(EnemyShip ship) { };
        }

        public void Damage(float damage)
        {
            hp -= damage;
            if(hp < 0)
            {
                hp = 0;
                ShipDestroyed.Invoke(this);
            }
        }

        public virtual void Init(INewShip newShipDisplayer)
        {
            newShipDisplayer.ShowNewShip(this);
        }

        public override string ToString()
        {
            return shipName;
        }
    }
}
