using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;
using UnityEngine.UI;

public class Phone : MonoBehaviour
{
    public GameObject ChatterApp;
    public GameObject AppScreen;
    public TMP_Text textOnScreen;
    public TMP_Text bonusPoints;
    public TMP_InputField inputField;
    public float points;
    public GameObject phone2;


    private bool canSendTXT;
    public Button sendBTN;

    public ScoreSystem scoreSystem;

    private void Start()
    {
        points = Random.Range(1, 250);
        canSendTXT = true;
    }
    private void Update()
    {
        if (canSendTXT == false)
        {
            sendBTN.enabled = false;
        }

        if(Input.GetKeyDown(KeyCode.Return))
        {
            StartCoroutine(SendButton());
        }
    }
    public void Send()
    {
        StartCoroutine(SendButton());
    }
    public IEnumerator SendButton()
    {

        textOnScreen.text = inputField.text;
        yield return new WaitForSeconds(3f);
        bonusPoints.text = /*"Likes + " +*/ (points.ToString());
        canSendTXT = false;

        PlayerPrefs.SetFloat("ChatterApp", points);
        scoreSystem.ChatterPoints += points;
        scoreSystem.TotalScore += points;

        yield return new WaitForSeconds(3f);
        ChatterApp.SetActive(false);
        AppScreen.SetActive(true);
        phone2.SetActive(true);
    }
    public void CloseChatter()
    {
        ChatterApp.SetActive(false);
        AppScreen.SetActive(true);
    }

}
