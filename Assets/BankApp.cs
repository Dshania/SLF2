using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BankApp : MonoBehaviour
{
    public GameObject bankApp;
    public GameObject AppScreen;

    public TMP_Text balanceTXT;
    private float balance;

    private void Start()
    {
        balance = PlayerPrefs.GetFloat("Scores");
        balance *= 1.3f;
    }

    private void Update()
    {
        balanceTXT.text = balance.ToString();
    }

    public void CloseBA()
    {
        bankApp.SetActive(false);
        AppScreen.SetActive(true);
    }
}
