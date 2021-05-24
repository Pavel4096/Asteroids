namespace Asteroids
{
    public sealed class AsteroidModel
    {
        public float ScaleMin { get; }
        public float ScaleMax { get; }
        public float ForceMin { get; }
        public float ForceMax { get; }
        public float HealthMax { get; }
        public string Name { get; } = "Asteroid";

        public AsteroidModel(string name = null) : this(0.5f, 1.0f, 1.0f, 1.5f, 1000.0f, name)
        {
        }

        public AsteroidModel(float scaleMin_, float scaleMax_, float forceMin_, float forceMax_, float healthMax_, string name = null)
        {
            ScaleMin = scaleMin_;
            ScaleMax = scaleMax_;
            ForceMin = forceMin_;
            ForceMax = forceMax_;
            HealthMax = healthMax_;

            if(name != null)
                Name = name;
        }
    }
}
