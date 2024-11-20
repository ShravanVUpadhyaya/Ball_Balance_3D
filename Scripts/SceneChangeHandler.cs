using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeHandler : MonoBehaviour
{
    public void LoadSelectedLevel(string levelNumber)
    {
        SceneManager.LoadScene(levelNumber);
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void RetryLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
