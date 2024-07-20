using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    [Header("Variables")]
    public static bool _paused;
    [Header("Refrences")]
    public GameObject OptionsMenu;
    public Image background;
    public Slider musicSlider;
    public TMP_Text musicText;

    //STATICS
    public static int musicVolume;

    void Start()
    {
        musicSlider.value = PlayerPrefs.GetFloat("music", 100f);
        musicVolume = (int)musicSlider.value;
        musicText.text = $"Vol {musicVolume}%";
        _paused = false;
        background.CrossFadeAlpha(0f, 0f, true);
        OptionsMenu.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _paused = !_paused;
            if (_paused)
            {
                background.CrossFadeAlpha(0.7f, 0.2f, false);
                OptionsMenu.SetActive(true);
            }
            else background.CrossFadeAlpha(0f, 0.2f, false);
        }

        OptionsMenu.SetActive(_paused);
    }

    public void SetVolume()
    {
        musicVolume = (int)musicSlider.value;
        musicText.text = $"Vol {musicVolume}%";
        PlayerPrefs.SetFloat("music", musicVolume);

        MusicManager.RefreshVolume();
    }
}
