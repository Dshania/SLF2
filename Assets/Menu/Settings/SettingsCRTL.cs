using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsCRTL : MonoBehaviour
{
    public GameObject phoneAnim;
    public GameObject settingsScreen;
    public AudioSource vibrating;
    public GameObject sound;
    public GameObject graphics;
    public GameObject resloution;
    public GameObject credits;
    public GameObject buttons;

    public void ScreenClick()
    {
        phoneAnim.SetActive(false);
        settingsScreen.SetActive(true);
        vibrating.Stop();
    }
    public void Sound()
    {
        sound.SetActive(true);
        buttons.SetActive(false);
    }
    public void Graphics()
    {
        graphics.SetActive(true);
        buttons.SetActive(false);
    }
    public void Resolution()
    {
        resloution.SetActive(true);
        buttons.SetActive(false);
    }
    public void Credits()
    {
        credits.SetActive(true);
        buttons.SetActive(false);
    }

}
