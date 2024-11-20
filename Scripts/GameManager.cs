using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    void Awake()
    {
       if(instance == null)
       {
           instance = this;
           DontDestroyOnLoad(gameObject);
       }
       else
       {
           Destroy(gameObject);
       }
    }
    

    void OnEnable()
    {
        LevelManager.OnClickNextLevel += LoadNextLevel;
        GameEndManager.OnLevelCompleted += SaveData;
        GameQuitManager.OnClickQuitGame += QuitGame;
        PlayerPrefsManager.OnSaveDataRequest += SaveData;
        PlayerPrefsManager.OnClearDataRequest += ClearData;
    }


    void OnDisable()
    {
        LevelManager.OnClickNextLevel -= LoadNextLevel;
        GameEndManager.OnLevelCompleted -= SaveData;
        GameQuitManager.OnClickQuitGame -= QuitGame;
        PlayerPrefsManager.OnSaveDataRequest -= SaveData;
        PlayerPrefsManager.OnClearDataRequest -= ClearData;
    }


    public void LoadNextLevel(int nextLevelLoad)
    {
        SceneManager.LoadScene(nextLevelLoad);   
    }
  

    public void SaveData(int nextLevel)
    {
        PlayerPrefs.SetInt("levelAt", nextLevel);
    }


    public void ClearData()
    {
        PlayerPrefs.DeleteAll();
    } 


    public void QuitGame()
    {
        Application.Quit();
    }
}
