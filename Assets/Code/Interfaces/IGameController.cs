using System;

namespace Asteroids
{
    public interface IGameController
    {
        event Action<float> GameLoop;
        //event Action<IController> ControllerAdded;
        //event Action<IController> ControllerRemoved;
        //IController this[int i] { get; }
        //int ControllerCount { get; }
        //void AddController(IController controller);
        //bool RemoveController(IController controller);

        void UpdateGame(UserInput userInput, float frameTime);
    }
}
