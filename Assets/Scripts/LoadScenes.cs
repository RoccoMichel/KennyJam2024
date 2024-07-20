using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour
{
    [Tooltip("By Build Index")]
    public void loadSceneByIndex(int index)
    {
        SceneManager.LoadScene(index);
    }
    [Tooltip("By Scene Name")]
    public void loadSceneByName(string name)
    {
        SceneManager.LoadScene(name);
    }
    public void loadSceneNextInBuild()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void loadScenePreviousInBuild()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void loadSceneAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
