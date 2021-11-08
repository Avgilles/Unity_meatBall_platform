using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class chronometre : MonoBehaviour
{
    public Text chronoUI;
    private Dictionary<string, float> timeVal;
    private float chrono = 0f;
    private float bestScore = 0f;
    private string bestScoreString, scoreSave;

    void Awake()
    {
        CheckBestScore();
    }

    void Start()
    {
        timeVal = new Dictionary<string, float> { { "minutes", 0f }, { "seconds", 0f }, { "fraction", 0f } };
    }

    void Update()
    {
        DisplayTime();
    }

    private float Timer()
    {
        chrono += Time.deltaTime;
        return chrono;
    }

    private void TradTime(float time, Dictionary<string, float> timeStore)
    {
        timeStore["minutes"] = (int)(time / 60f);
        timeStore["seconds"] = (int)(time % 60f);
        timeStore["fraction"] = (int)((time * 100f) % 100f);
    }

    void DisplayTime()
    {
        TradTime(Timer(), timeVal);
        chronoUI.text = bestScoreString + "\n" +
            "Temps : " + timeVal["minutes"] + " min " + timeVal["seconds"] + ":" + timeVal["fraction"];
    }
    void CheckBestScore()
    {
        PlayerPrefs.SetFloat("bestScore", bestScore);
        bestScore = PlayerPrefs.GetFloat(scoreSave);
        if (PlayerPrefs.HasKey("bestScore"))
        {
            Dictionary<string, float> bestScStore = new Dictionary<string, float> { { "minutes", 0f }, { "seconds", 0f }, { "fraction", 0f } };
            TradTime(bestScore, bestScStore);
            bestScoreString = "Best : " + bestScStore["minutes"] + " min " + bestScStore["seconds"] + ":" + bestScStore["fraction"];
        }
    }

    public void End()
    {
        if (chrono < bestScore || bestScore == 0f)
        {
            PlayerPrefs.SetFloat(scoreSave, chrono);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
