using System;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour
{
    public static Action OnClearDataRequest;

    public static Action<int> OnSaveDataRequest;

    public void ClearData()
    {
        OnClearDataRequest?.Invoke();
    }

    public void SaveData(int level)
    {
        OnSaveDataRequest?.Invoke(level);
    }
}
