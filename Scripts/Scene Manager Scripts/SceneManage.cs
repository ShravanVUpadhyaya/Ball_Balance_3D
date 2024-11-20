using UnityEngine;
using UnityEngine.SceneManagement;

namespace ZombieLabyrinth.SceneManagementSystem
{
    public class SceneManage : MonoBehaviour
    {
        [SerializeField] private string scene;
        public void SceneChange(string scene)
        {
            SceneManager.LoadScene(scene);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
