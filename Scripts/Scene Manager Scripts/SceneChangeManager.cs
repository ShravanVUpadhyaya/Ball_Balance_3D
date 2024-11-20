using UnityEngine;
using UnityEngine.SceneManagement;

namespace BallBalance3d
{
    public class SceneChangeManager : MonoBehaviour
    {
        private void Start()
        {
            GameManager.GameManager.OnLoadSceneRequested += LoadScene;
            GameManager.GameManager.OnMainMenuScreenRequested += MainMenuScreen;
            GameManager.GameManager.OnQuitGameRequested += QuitGame;
        }

        private void OnDestroy()
        {
            GameManager.GameManager.OnLoadSceneRequested -= LoadScene;
            GameManager.GameManager.OnMainMenuScreenRequested -= MainMenuScreen;
            GameManager.GameManager.OnQuitGameRequested -= QuitGame;
        }

        public void LoadScene(string scene)
        {
            SceneManager.LoadScene(scene);
        }

        public void RestartScene(string scene)
        {
            SceneManager.LoadScene(scene);
        }

        public void MainMenuScreen()
        {
            SceneManager.LoadScene("GameOverScene");
        }

        public void QuitGame()
        {
            Application.Quit();
            Debug.Log("QUIT!!!");
        }
    }
}
