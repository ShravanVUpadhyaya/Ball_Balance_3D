using UnityEngine;
using UnityEngine.UI;

public class SceneUnlockManager : MonoBehaviour
{
    [SerializeField] private Button[] levelsButtons;

    private void Start()
    {
        int levelAt = PlayerPrefs.GetInt("levelAt", 1);
        for (int i = 0; i < levelsButtons.Length; i++)
        {
            if (i + 1 > levelAt)
                levelsButtons[i].interactable = false;
        }
    }
}
