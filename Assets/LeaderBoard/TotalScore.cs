using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TotalScore : MonoBehaviour
{
    public TMP_Text ScoreText;
    public Animator HSFadeIn;
   // public float level1Score;

    void Start()
    {
        ScoreText.text = PlayerPrefs.GetString("Score");
        HSFadeIn.SetTrigger("Play");
      //  level1Score = PlayerPrefs.GetFloat("Scores");
    }
}
