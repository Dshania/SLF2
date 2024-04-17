using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject settings;
    public GameObject credits;

    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //SceneManager.LoadScene("Game Scene");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Game Quitted");
    }

    public void Settings()
    {
        settings.SetActive(true);
    }

    public void backToMenu()
    {
        settings.SetActive(false);
    }
    public void Credits()
    {
        credits.SetActive(true);
    }

    public void backToSettings()
    {
        credits.SetActive(false);
    }
}
