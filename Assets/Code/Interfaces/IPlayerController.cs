using System;

namespace Asteroids
{
    public interface IPlayerController : IController, IDisposable
    {
        void ProcessInput(UserInput userInput, float frameTime);
    }
}
