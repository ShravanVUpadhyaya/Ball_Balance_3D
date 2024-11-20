using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BallBalance3d.GameManager
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;


        public static event Action<string> OnLoadSceneRequested;
        public static event Action OnPlayerCollision;
        public static event Action OnQuitGameRequested;
        public static event Action OnRestartGameRequested;
        public static event Action OnMainMenuScreenRequested;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }

        public void LoadScene(string scene)
        {
            OnLoadSceneRequested?.Invoke(scene);
        }

        public void QuitGame()
        {
            OnQuitGameRequested?.Invoke();
        }

        public void RestartGame(string scene)
        {
            OnRestartGameRequested?.Invoke();
            SceneManager.LoadScene(scene);
        }

        public void MainMenuScreen()
        {
            OnMainMenuScreenRequested?.Invoke();
            SceneManager.LoadScene("GameOverScene");
        }

        public void PlayerCollision(string scene)
        {
            OnPlayerCollision?.Invoke();
            SceneManager.LoadScene(scene);
        }


    }
}
