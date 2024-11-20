using System;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

[Serializable]
public class WeatherData
{
    public MainData main;
}

[Serializable]
public class MainData
{
    public float temp;
}

public class APIManager : MonoBehaviour
{
    private const string APIURL = "https://open-weather13.p.rapidapi.com/city/Bangalore/India";
    private const string APIKey = "ed0831da94msh08294208ef16d66p143abdjsnf72eaacc9b76";
    private const string APIHost = "open-weather13.p.rapidapi.com";

    void Start()
    {
        StartCoroutine(MakeRequest());
    }

    IEnumerator MakeRequest()
    {
        string url = APIURL;
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            request.SetRequestHeader("X-RapidAPI-Key", APIKey);
            request.SetRequestHeader("X-RapidAPI-Host", APIHost);

            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("Error: " + request.error);
            }
            else
            {
                Debug.Log("Response Code: " + request.responseCode);
                string jsonResponse = request.downloadHandler.text;
                Debug.Log("Response: " + jsonResponse);

                WeatherData weatherData = JsonUtility.FromJson<WeatherData>(jsonResponse);

                if (weatherData != null && weatherData.main != null)
                {
                    float temperature = weatherData.main.temp;
                    temperature = (temperature - 32) * 5/9;
                    Debug.Log("Temperature in Bangalore: " + temperature  + "°C");
                }
                else
                {
                    Debug.LogWarning("Temperature data not found in response.");
                }
            }
        }
    }
}
