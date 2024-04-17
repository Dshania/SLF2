using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameButtons : MonoBehaviour
{
    public GameObject screen;
    public GameObject colorWheel;
    public void yes()
    {
        SceneManager.LoadScene("LevelComplete");
    }

    public void Screen()
    {
        screen.SetActive(true);
    }

    public void no() 
    { 
     screen.SetActive(false);
    }

    public void backToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ColourScreen()
    {
        colorWheel.SetActive(true);
    }

    public void closeCW()
    {
        colorWheel.SetActive(false);
    }

}
