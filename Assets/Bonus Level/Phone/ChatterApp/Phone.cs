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
    private float points;


    private bool canSendTXT;
    public Button sendBTN;

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
    }
    public void Send()
    {
        StartCoroutine(SendButton());
    }
    public IEnumerator SendButton()
    {

        textOnScreen.text = inputField.text;
        yield return new WaitForSeconds(3f);
        bonusPoints.text = "Likes + " + (points.ToString());
        canSendTXT = false;

        PlayerPrefs.SetFloat("TotalScore", points);

        yield return new WaitForSeconds(3f);
        ChatterApp.SetActive(false);
        AppScreen.SetActive(true);
    }
    public void CloseChatter()
    {
        ChatterApp.SetActive(false);
        AppScreen.SetActive(true);
    }

}
