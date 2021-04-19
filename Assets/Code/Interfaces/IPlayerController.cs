namespace Asteroids
{
    public interface IPlayerController
    {
        void ProcessInput(UserInput userInput, float frameTime);
    }
}
