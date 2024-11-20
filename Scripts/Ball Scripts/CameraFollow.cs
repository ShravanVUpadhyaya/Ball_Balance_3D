using UnityEngine;

namespace BallBalance3d.CameraManager
{
    public class CameraFollow : MonoBehaviour
    {
        public GameObject ballSphere;
        private Vector3 distance;

        void Start()
        {
            distance = transform.position - ballSphere.transform.position;
        }

        void Update()
        {
            transform.position = distance + ballSphere.transform.position;
        }
    }
}
