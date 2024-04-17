using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharSelection : MonoBehaviour
{
    public GameObject screen;

    public void SkinTone()
    {
        screen.SetActive(true);
    }

    public void backToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Continue()
    {
        SceneManager.LoadScene("GameScene");
    }
}
