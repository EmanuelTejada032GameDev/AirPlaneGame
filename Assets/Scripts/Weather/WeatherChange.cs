using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using LitJson;

public class WeatherChange : MonoBehaviour
{
    private int actualWeatherId;
    private string actualWeatherIdDescription;
    private string actualWeatherDescription;

    private void Start()
    {
        StartCoroutine(GetWeatther());
    }

    IEnumerator GetWeatther()
    {
        UnityWebRequest www = UnityWebRequest.Get("https://api.openweathermap.org/data/2.5/weather?q=bogota&appid=apikey");
        yield return www.SendWebRequest();

        if(www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Couldnt get the api data");
            Debug.LogError(www.error);
        }
        else
        {
            JsonData weatherJsonData = JsonMapper.ToObject(www.downloadHandler.text);
            actualWeatherId = (int)weatherJsonData["weather"][0]["id"];
            actualWeatherIdDescription = (string)weatherJsonData["weather"][0]["main"];
            actualWeatherDescription = (string)weatherJsonData["weather"][0]["description"];
            Debug.Log(actualWeatherId);
            Debug.Log(actualWeatherIdDescription);
            Debug.Log(actualWeatherDescription);
        }

    }
}
