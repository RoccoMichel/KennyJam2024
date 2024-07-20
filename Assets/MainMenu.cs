using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public List<GameObject> Levels = new();

    void Start()
    {
        for (int i = 0; i < Levels.Count; i++)
        {
            GameObject.Find($"{Levels[i].name}/Text").GetComponent<TMP_Text>().text = $"[{TimerLogic(PlayerPrefs.GetFloat((i + 1).ToString()))}]";
        }
    }
    void Update()
    {
        Options._paused = true;
    }

    public void QuitApplication()
    {
        Application.Quit();
        Debug.LogWarning("QUIT");
    }
    public void OpenUrl(string URL)
    {
        Application.OpenURL(URL);
        Debug.Log($"Opened: {URL}");
    }
    string TimerLogic(float time)
    {
        if (time == -1) return "HIGHSCORE";

        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);

        string min;
        string sec;

        if (minutes < 10) min = ("0" + minutes);
        else min = minutes.ToString();
        if (seconds < 10) sec = ("0" + seconds);
        else sec = seconds.ToString();

        return (min + ":" + sec);
    }
}
