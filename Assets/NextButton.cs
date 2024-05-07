using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextButton : MonoBehaviour
{
    private static int BtnClicks;
    public void NextLevel()
    {
        BtnClicks += 1;
        if (BtnClicks == 1)
        {
            Level2();
        }
        if (BtnClicks == 2)
        {
            Level3();
        }
        if (BtnClicks == 3)
        {
            MainMenu();
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadSceneAsync("Menu");
    }

    public void Level2()
    {
        SceneManager.LoadSceneAsync("Level2");
    }

    public void Level3()
    {
        SceneManager.LoadSceneAsync("Level3");
    }
}
