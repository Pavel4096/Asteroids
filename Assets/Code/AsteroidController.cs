using UnityEngine;

namespace Asteroids
{
    public sealed class AsteroidController : IController, IPoolManagable
    {
        private AsteroidModel model;
        private float health;
        private IView view;
        private bool isActive;

        public bool IsActive
        {
            get => isActive;
            private set
            {
                isActive = value;
                view.IsActive = isActive;
            }
        }

        public AsteroidController(AsteroidModel model_, IView view_)
        {
            model = model_;
            view = view_;
            IsActive = false;
        }

        public void Initialize()
        {
            Vector2 force = RandomVector()*((model.ForceMin + model.ForceMax)/2);
            view.Rigidbody2D.AddForce(force, ForceMode2D.Impulse);
            health = model.HealthMax;
            IsActive = true;
        }

        public Vector2 RandomVector()
        {
            System.Random rnd = new System.Random();
            return new Vector2((float)((rnd.NextDouble()-0.5)*2), (float)((rnd.NextDouble()-0.5)*2));
        }
    }
}
