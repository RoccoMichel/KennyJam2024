using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public List<GameObject> Levels = new();

    private void Start()
    {
        for (int i = 0; i < Levels.Count; i++)
        {
            if (PlayerPrefs.GetFloat((i+1).ToString(), 0) != 0)
            {
                GameObject.Find($"{Levels[i].name}/Text").GetComponent<TMP_Text>().text = TimerLogic(PlayerPrefs.GetFloat((i+1).ToString()));

                //Level Played
                Levels[i+1].GetComponent<Button>().enabled = true;
                GameObject.Find($"{Levels[i+1].name}/Locked").SetActive(false);
            }
            else if (i+1 < Levels.Count)
            {
                if (i != 0) GameObject.Find($"{Levels[i].name}/Text").GetComponent<TMP_Text>().text = "LOCKED";

                Levels[i + 1].GetComponent<Button>().enabled = false;
                GameObject.Find($"{Levels[i + 1].name}/Locked").SetActive(true);
            }

        }
        //First Level
        Levels[0].GetComponent<Button>().enabled = true;
        if (GameObject.Find($"{Levels[0].name}/Locked") != null) GameObject.Find($"{Levels[0].name}/Locked").SetActive(false);
        GameObject.Find($"{Levels[0].name}/Text").GetComponent<TMP_Text>().text = TimerLogic(PlayerPrefs.GetFloat((0 + 1).ToString()));
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
