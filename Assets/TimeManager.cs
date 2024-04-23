using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeManager : MonoBehaviour
{
    [SerializeField] GameObject pannel;
    [SerializeField] Image clockIMG;
    [SerializeField] TMP_Text timeTXT;
    [SerializeField] float totalTime;
    [SerializeField] float currentTime;

    private void Start()
    {
        pannel.SetActive(false);
        currentTime = totalTime;
        timeTXT.text = currentTime.ToString();
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        while (currentTime >= 0)
        {
            clockIMG.fillAmount = Mathf.InverseLerp(0, totalTime, currentTime);
            timeTXT.text = currentTime.ToString();
            yield return new WaitForSeconds(1);
            currentTime--;
        }
        OpenPannel();
    }

    void OpenPannel()
    {
        timeTXT.text = "";
        pannel.SetActive(true);
    }
}
