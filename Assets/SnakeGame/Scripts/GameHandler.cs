using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public GameObject menuPannel;
    public GameObject score;
    public GameObject snakeGame;
    public GameObject mainCamera;
    public GameObject menuUI;
    public GameObject phoneImage;
    public void Return()
    {
        menuPannel.SetActive(false);
        score.SetActive(true);
        Time.timeScale = 1.0f;
    }

    public void Exit()
    {
        snakeGame.SetActive(false);
        menuUI.SetActive(false);
        phoneImage.SetActive(true);
        mainCamera.SetActive(true);
        Time.timeScale = 1f;
    }
}
