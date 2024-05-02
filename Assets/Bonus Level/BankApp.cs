using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BankApp : MonoBehaviour
{
    public GameObject bankApp;
    public GameObject AppScreen;

    public TMP_Text balanceTXT;
    public float balance;

    public ScoreSystem scoreSystem;
    private void Start()
    {
        balance = scoreSystem.TotalScore * 1.3f;
    }

    private void Update()
    {
        balance = scoreSystem.TotalScore * 1.3f;
        balanceTXT.text = balance.ToString();
    }

    public void CloseBA()
    {
        bankApp.SetActive(false);
        AppScreen.SetActive(true);
    }
}
