using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chronometre : MonoBehaviour
{
    //public float delay;
    private float cpt;

    public Text chronoUI;

    private float minutes;
    private float secondes;
    private float fraction;
    private float bestScore = 600f;
    private string bestScoreSaving;
    private string ScoreSaving;

    private void Awake()
    {
        PlayerPrefs.SetFloat("bestScore", bestScore);
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

        chronoUI.text = "Temps : " + minutes + ":" + secondes + ":" + fraction;
        if(cpt <= 0)
        {

        }
    }
}
