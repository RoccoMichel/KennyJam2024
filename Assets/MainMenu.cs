using UnityEngine;

public class MainMenu : MonoBehaviour
{
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
