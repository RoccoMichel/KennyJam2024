using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [Header("Variables")]
    public int mistakesLeft = 0;
    public float time;
    public bool _counting;
    public bool _gameOver;
    [Header("Refrences")]
    public TMP_Text mistakesText;

    void Start()
    {
        _gameOver = false;
        _counting = true;
        foreach (GameObject Mistake in GameObject.FindGameObjectsWithTag("Mistake")) mistakesLeft++;
        Debug.Log($"Totall Mistakes in Scene: {mistakesLeft}");
        if (mistakesLeft % 2 != 0) Debug.LogWarning("UNEVEN AMOUNT OF MISTAKES IN SCENE!");
    }
    void Update()
    {
        //DISPLAY TEXT
        if (_counting) mistakesText.text = $"[{TimerLogic(time)}]\n{mistakesLeft / 2}\nLEFT";

        //TIMER
        if (_counting) time += Time.deltaTime;

        //VICTORY
        if (mistakesLeft == 0 && !_gameOver)
        {
            float highscore = PlayerPrefs.GetFloat(SceneManager.GetActiveScene().buildIndex.ToString(), 0);
            _counting = false;
            _gameOver = true;

            if (highscore >= time)
            {
                mistakesText.text = $"[{TimerLogic(time)}]\nHighscore: {TimerLogic(highscore)}";
                //GAME OVER
            }
            else
            {
                mistakesText.text = $"[{TimerLogic(time)}]\n!NEW HIGHSCORE!";
                PlayerPrefs.SetFloat(SceneManager.GetActiveScene().buildIndex.ToString(), time);
            }
        }
        if (_gameOver) Options._paused = false;
    }

    public void FoundMistake()
    {
        mistakesLeft -= 2;
    }    
    
    string TimerLogic(float time)
    {
        if (Options._paused) return "PAUSED";

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
