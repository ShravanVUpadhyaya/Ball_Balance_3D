using UnityEngine;

namespace BallBalance3d.GameEndManager
{
    public class GameEndManager : MonoBehaviour
    {

        private void Start()
        {
            GameManager.GameManager.OnMainMenuScreenRequested += HandleGameCompleted;
        }

        private void OnDestroy()
        {
            GameManager.GameManager.OnMainMenuScreenRequested -= HandleGameCompleted;
        }

        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("BallTag"))
            {
                GameManager.GameManager.Instance.MainMenuScreen();
            }
        }

        void HandleGameCompleted()
        {
            Debug.Log("Level completed,requesting GameManger to go back to main menu.");
        }

    }
}
