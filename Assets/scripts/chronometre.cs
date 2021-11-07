using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class chronometre : MonoBehaviour
{
    //public float delay;
    private float cpt;

    public Text chronoUI;

    private float minutes;
    private float secondes;
    private float fraction;
    private float bestScore = 600f;
    private string bestScoreString;
    private string ScoreSave;


    private void Awake()
    {
        PlayerPrefs.SetFloat("bestScore", bestScore);
        bestScore = PlayerPrefs.GetFloat(ScoreSave);

        minutes = (int)(bestScore / 60f);
        secondes = (int)(bestScore % 60f);
        fraction = (int)((bestScore * 100f) % 100f);

        bestScoreString = "Best : " + minutes + ":" + secondes + ":" + fraction;

        // cpt = delay;        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cpt += Time.deltaTime;
        minutes = (int)(cpt / 60f);
        secondes = (int)(cpt % 60f);
        fraction = (int)((cpt*100f)%100f);

        chronoUI.text = bestScoreString + "\n"+"Temps  : " + minutes + ":" + secondes + ":" + fraction;
        
    }

    public void End()
    {
        if (cpt <= bestScore)
        {
            PlayerPrefs.SetFloat(ScoreSave, cpt);


        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
