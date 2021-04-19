using UnityEngine;

namespace Asteroids
{
    public sealed class Game : MonoBehaviour
    {
        private GameController gameController;

        public IGameController GameController
        {
            get => (IGameController) gameController;
        }

        public IView CreateView(string name, Vector3 position = new Vector3())
        {
            GameObject loadedObject = Resources.Load<GameObject>(name);
            GameObject currentObject = Object.Instantiate(loadedObject, position, Quaternion.identity);
            IView view = currentObject.GetComponent<IView>();

            if(view == null)
                throw new NoViewException(name);

            return view;
        }

        private void Awake()
        {
            gameController = new GameController(this);
            gameController.Init();
        }

        private void Update()
        {
            float frameTime = Time.deltaTime;
            UserInput userInput = new UserInput(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"), Input.GetButton("Fire1"));
            gameController.UpdateGame(userInput, frameTime);
        }
    }
}
