using UnityEngine;

namespace BallBalance3d.EnemiesManager
{
    public class SawSpinning : MonoBehaviour
    {
        [SerializeField] private string scene;

        public float rotateSpeed = 5f;
        public Vector3 rotationDirection = new Vector3();

        void Start()
        {
            GameManager.GameManager.OnPlayerCollision += RestartRequest;
        }

        void OnDestroy()
        {
            GameManager.GameManager.OnPlayerCollision -= RestartRequest;
        }


        void Update()
        {
            transform.Rotate(rotateSpeed * rotationDirection * Time.deltaTime);
            FindObjectOfType<AudioManager>().Play("Saw_Spin");
        }

        void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.CompareTag("BallTag"))
            {
                GameManager.GameManager.Instance.PlayerCollision(scene);
            }
        }


        void RestartRequest()
        {
            Debug.Log("Restart requested from GameManager.");
        }
    }
}
