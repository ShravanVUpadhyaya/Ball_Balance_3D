using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static Action<int> OnClickNextLevel;

    public void NextLevel()
    {
        int nextLevelLoad = SceneManager.GetActiveScene().buildIndex + 1;
        OnClickNextLevel?.Invoke(nextLevelLoad);
    }
}
