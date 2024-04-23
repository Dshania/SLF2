using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControl : MonoBehaviour
{
    public void BonusLevel()
    {
        SceneManager.LoadScene("BonuseLevel");
    }

    public void NextLevel()
    {
        SceneManager.LoadScene("");
    }

    public void Mainmenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
