using UnityEngine;
using ZombieLabyrinth.Player;

namespace ZombieLabyrinth.DoorSystem
{

    public class DoorFunctionality : MonoBehaviour
    {

        [SerializeField] private GameObject button;
        [SerializeField] private GameObject exitDoor;
        [SerializeField] private DoorOpener open;  
        [SerializeField] private ButtonsClickedCounter buttonsRemaining;

        void Start()
        {
            button.SetActive(false);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                open.Door();
            }
        }

    }
}
