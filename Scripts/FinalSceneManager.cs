using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;


public class FinalSceneManager : MonoBehaviour
{
    [SerializeField] private Transform villageScreen1;
    [SerializeField] private Transform villageScreen2;
    [SerializeField] private Transform blackScreen;
    [SerializeField] private Transform finalPage;
    [SerializeField] private Button homeButton;
    private void Start()
    {
        Invoke(nameof(ButtonInteractable), 15.5f);
        homeButton.enabled = false;
        villageScreen1.DOMoveX(1400, 2f);
        villageScreen2.DOMoveX(1400, 7f);
        blackScreen.DOMoveX(1400,15f);
        finalPage.DOMoveX(1400, 15f);
    }

    void ButtonInteractable()
    {
        homeButton.enabled = true;
    }    
}
