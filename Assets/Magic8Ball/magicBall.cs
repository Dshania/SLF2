using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class magicBall : MonoBehaviour
{
    string[] outcomes = new string[]
    {
       "It is certain",
       "It is decidedly so",
       "Without a doubt",
       "Yes definitely",
       "You may rely on it",
       "As I see it",
       "yes, Most likely",
       "Outlook good",
       "Yes",
       "Signs point to yes",
       "Don't count on it",
       "My reply is no",
       "No",
       "My sources say no",
       "Outlook not so good",
       "Very doubtful",
       "Reply hazy",
       "try again",
       "Ask again later",
       "Better not tell you now",
       "Cannot predict now",
       "Concentrate and ask again",
       "Maybe",
       "Possibly",
       "It will pass",
       "Count on it",
       "Absolutely",
       "Go for it",
       "Not now",
       "It is Ok"
    };

    public TMP_Text outcomeBox;
    public Button button;

    public void Shake()
    {
        button.interactable = false;
        outcomeBox.text = outcomes[UnityEngine.Random.Range(0, outcomes.Length)];

        var alphaFade = CurveFactory.Create(0f, 1f);
        var scaleFade = CurveFactory.Create(0.5f, 1f);

        Action<float> alphaTick = (t) => outcomeBox.SetText(alphaFade.Evaluate(t));
        Action<float> scaleTick = (t) => outcomeBox.SetScale(scaleFade.Evaluate(t));

        StartCoroutine(CoroutineFactory.Create(1f, alphaTick + scaleTick, () => button.interactable = true));
    }

}
