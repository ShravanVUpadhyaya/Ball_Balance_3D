using UnityEngine;

namespace ZombieLabyrinth.CoinSystem
{

    public class CoinRotator : MonoBehaviour
    {

        [SerializeField] private float spinSpeed = 5f;

        void Update()
        {
            transform.Rotate(Vector3.up * spinSpeed * Time.deltaTime);
        }
    }
}