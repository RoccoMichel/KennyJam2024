using UnityEngine;

public class MusicManager : MonoBehaviour
{
    void Start()
    {
        RefreshVolume();
    }

    public static void RefreshVolume()
    {
        AudioSource music = GameObject.FindGameObjectWithTag("SONG").GetComponent<AudioSource>();
        music.volume = PlayerPrefs.GetFloat("music", 100)/100;
    }
}
