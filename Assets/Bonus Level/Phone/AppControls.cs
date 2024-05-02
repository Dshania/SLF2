using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AppControls : MonoBehaviour
{
    public GameObject AppScreen;
    public GameObject ChatterApp;
    public GameObject EditScreen;
    public GameObject EditMenu;
    public GameObject Leaderboard;
    public GameObject Bank;
    public GameObject shop;
    public GameObject contacts;
    public GameObject game1;
    public GameObject game2;
    public GameObject phone;
    public GameObject calculator;
    public GameObject levelSelect;
    

    public void chatterAppBTN()
    {
        ChatterApp.SetActive(true);
        AppScreen.SetActive(false);
    }

    public void EditBTN()
    {
        EditScreen.SetActive(true);
        EditMenu.SetActive(true);
        AppScreen.SetActive(false);
    }

    public void leaderboardBTN()
    {
        Leaderboard.SetActive(true);
        AppScreen.SetActive(false);
    }

    public void bankBTN()
    {
        Bank.SetActive(true);
        AppScreen.SetActive(false);
    }
    public void ShopBTN()
    {
        shop.SetActive(true);
        phone.SetActive(false);
    }
    public void contactsBTN()
    {
        contacts.SetActive(true);
        AppScreen.SetActive(false);
    }
    public void game1BTN()
    {
        game1.SetActive(true);
        phone.SetActive(false);
        EditScreen.SetActive(false);
    }
    public void game2BTN()
    {
        game2.SetActive(true);
        AppScreen.SetActive(false);
    }
    public void CalCulAtor()
    {
        calculator.SetActive(true);
        AppScreen.SetActive(false);
    }
    public void Levelchoose()
    {
        levelSelect.SetActive(true);
        AppScreen.SetActive(false);
    }
    public void NextLevel()
    {
        SceneManager.LoadScene("Level2");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
