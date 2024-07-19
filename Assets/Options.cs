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
    public static int backUpMusicVol;

    void Start()
    {
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
    }

    void FixedUpdate()
    {
        if (_paused)
        {
            float size = OptionsMenu.transform.localScale.x;
            float target = Mathf.Lerp(size, 1, 0.3f);
            OptionsMenu.transform.localScale = new Vector3(target, target, target);
        }
        else if (!_paused && OptionsMenu.activeSelf)
        {
            float size = OptionsMenu.transform.localScale.x;
            float target = Mathf.Lerp(size, 0, 0.3f);
            OptionsMenu.transform.localScale = new Vector3(target, target, target);

            if (size < 0.05f) OptionsMenu.SetActive(false);
        }
    }

    public void SetVolume(Image musicOn)
    {
        _muted = false;
        musicOn.CrossFadeAlpha(1, 0, true);
        musicVolume = (int)musicSlider.value;
        musicText.text = $"Vol {musicVolume}%";
    }
    public void UnmuteVolume(Image musicOff)
    {
        musicOff.CrossFadeAlpha(0, 0, true);
    }

    bool _muted = false;
    public void ToogleVolume(Image musicOn)
    {
        _muted = !_muted;

        if (_muted)
        {
            backUpMusicVol = musicVolume;
            musicVolume = 0;
            musicOn.CrossFadeAlpha(0, 0, true);
        }
        else
        {
            musicVolume = backUpMusicVol;
            musicOn.CrossFadeAlpha(1, 0, true);
        }
        musicText.text = $"Vol {musicVolume}%";
    }
}
