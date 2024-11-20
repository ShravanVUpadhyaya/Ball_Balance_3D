using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameEndManager : MonoBehaviour
{
    [SerializeField] private Canvas levelCompletedCanvas;
    public static Action<int> OnLevelCompleted;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            if (SceneManager.GetActiveScene().buildIndex != 5)
            {
                levelCompletedCanvas.enabled = true;
                int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
                OnLevelCompleted?.Invoke(nextLevel);
            }
            else
            {
                SceneManager.LoadScene("GameEnd_Scene");
            }
        }
    }
}
