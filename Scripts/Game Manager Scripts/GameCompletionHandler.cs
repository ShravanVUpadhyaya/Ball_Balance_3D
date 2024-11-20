using UnityEngine;
using UnityEngine.SceneManagement;

namespace ZombieLabyrinth.SceneManagementSystem
{
    public class GameCompletionHandler : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                SceneManager.LoadScene("GameCompletedScene");
            }
        }

    }
}
