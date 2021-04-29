using UnityEngine;

namespace Asteroids
{
    public sealed class AsteroidController : IController, IPoolManagable
    {
        private AsteroidModel model;
        private float health;
        private IView view;
        private bool isActive;
        private Camera mainCamera;
        private float worldScreenWidth;
        private float worldScreenHeight;
        private float spawnRadius;

        private float forceBase;
        private float forceVariable;

        private static System.Random rnd = new System.Random();

        private const float spawnRadiusScaleFactor = 1.1f;

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
            mainCamera = Camera.main;
            worldScreenHeight = Mathf.Abs(mainCamera.transform.position.z)*2*Mathf.Tan(Mathf.Deg2Rad*mainCamera.fieldOfView/2);
            worldScreenWidth = worldScreenHeight*mainCamera.aspect;
            spawnRadius = Mathf.Sqrt(Mathf.Pow(worldScreenWidth, 2) + Mathf.Pow(worldScreenHeight, 2))*spawnRadiusScaleFactor/2;

            forceBase = model.ForceMin;
            forceVariable = model.ForceMax - model.ForceMin;
        }

        public void Initialize()
        {
            Transform asteroidTransform = view.Transform;
            float angle = (float)rnd.NextDouble()*2*Mathf.PI;
            Vector2 point;
            Vector2 force;

            asteroidTransform.position = new Vector3(Mathf.Cos(angle)*spawnRadius, Mathf.Sin(angle)*spawnRadius, 0.0f);
            point = RandomVector(worldScreenWidth, worldScreenHeight);
            force = new Vector2(point.x - asteroidTransform.position.x, point.y - asteroidTransform.position.y).normalized;
            force *= forceBase + forceVariable * (float)rnd.NextDouble();

            IsActive = true;
            view.Rigidbody2D.AddForce(force, ForceMode2D.Impulse);
            health = model.HealthMax;
        }

        public Vector2 RandomVector(float width, float height)
        {
            return new Vector2((float)((rnd.NextDouble()-0.5)*width), (float)((rnd.NextDouble()-0.5)*height));
        }
    }
}
