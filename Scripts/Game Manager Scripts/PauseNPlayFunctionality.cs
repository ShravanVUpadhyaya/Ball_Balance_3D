using UnityEngine;

public class PauseNPlayFunctionality : MonoBehaviour
{
    public void OnClickPause()
    {
        Time.timeScale = 0;
    }

    public void OnClickPlay()
    {
        Time.timeScale = 1;
    }
}
