using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using ZombieLabyrinth.ButtonManagement;

namespace ZombieLabyrinth.Player
{
    public class ButtonsClickedCounter : MonoBehaviour
    {
        public int buttonsToBePressed = 5;
        [SerializeField] private TextMeshProUGUI buttonsPressedText;
        [SerializeField] private GameObject button;
        private List<GameObject> activatedSwitches = new List<GameObject>();
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Switch"))
            {
                GameObject switchObject = other.gameObject;

                if (!activatedSwitches.Contains(switchObject))
                {
                    activatedSwitches.Add(switchObject);
                    buttonsToBePressed--;
                }
                ButtonPressedTextUI();
            }
        }

        void ButtonPressedTextUI()
        {
            buttonsPressedText.text = "Buttons To Be Pressed : " + buttonsToBePressed.ToString();
        }

        void Update()
        {
                if (buttonsToBePressed == 0)
                {
                    button.SetActive(true);
                }
        }
    }
}
