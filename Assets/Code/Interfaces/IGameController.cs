using System;

namespace Asteroids
{
    public interface IGameController
    {
        event Action<float> GameLoop;

        void UpdateGame(UserInput userInput, float frameTime);
    }
}
