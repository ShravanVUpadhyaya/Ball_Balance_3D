using UnityEngine;


namespace ZombieLabyrinth.ButtonManagement
{

    public class ButtonFunctionality : MonoBehaviour
    {
        [SerializeField] private Renderer buttonRenderer;
        [SerializeField] private Material activatedMaterial;
        private bool isButtonPressed = false;
    

        private void OnTriggerEnter(Collider other) 
        {

            if(other.CompareTag("Player") && !isButtonPressed)
            {
                buttonRenderer.material = activatedMaterial;
                isButtonPressed = true;
            }

        } 

    }
}
