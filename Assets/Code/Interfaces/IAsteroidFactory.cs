namespace Asteroids
{
    public interface IAsteroidFactory
    {
        void AddModel(AsteroidModel model);
        IController GetAsteroid();
    }
}
