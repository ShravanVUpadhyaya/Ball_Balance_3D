using System;
using UnityEngine;

public class GameQuitManager : MonoBehaviour
{
    public static Action OnClickQuitGame;
    public void QuitGame()
    {
        OnClickQuitGame?.Invoke();
    }
}
