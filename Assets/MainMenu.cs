using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public List<GameObject> Levels = new List<GameObject>();

    private void Start()
    {
        for (int i = 1; i < Levels.Count; i++)
        {
            if (PlayerPrefs.GetFloat(i.ToString(), 0) != 0)
            {
                //Level Played
                Levels[i].GetComponent<Button>().enabled = true;
                GameObject.Find($"{Levels[i].name}/Locked").SetActive(false);
            }
        }
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
}
