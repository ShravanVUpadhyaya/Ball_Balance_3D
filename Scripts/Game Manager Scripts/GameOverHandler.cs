using UnityEngine;
using UnityEngine.SceneManagement;

namespace ZombieLabyrinth.Player
{
    public class GameOverHandler : MonoBehaviour
    {
       void OnCollisionEnter(Collision collision)
       {
            if(collision.gameObject.CompareTag("EnemyTag"))
            {
                SceneManager.LoadScene("GameOverScene");
            }
       }

    }
}
