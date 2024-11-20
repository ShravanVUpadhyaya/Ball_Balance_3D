using UnityEngine;

namespace BallBalance3d.RetryGameManager
{
    public class RetryGameTrigger : MonoBehaviour
    {
        [SerializeField] private string restartScene;

        void Start()
        {
            GameManager.GameManager.OnRestartGameRequested += HandleRestartRequest;
        }

        void OnDestroy()
        {
            GameManager.GameManager.OnRestartGameRequested -= HandleRestartRequest;
        }

        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("BallTag"))
            {
                FindObjectOfType<AudioManager>().Play("Water_Splash");
                Invoke("DelayToRestart", 1f);
            }
        }

        void DelayToRestart()
        {
            GameManager.GameManager.Instance.RestartGame(restartScene);
        }


        void HandleRestartRequest()
        {
            Debug.Log("Restart requested from GameManager.");
        }
    }
}
