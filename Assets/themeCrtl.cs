using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class themeCrtl : MonoBehaviour
{
    public GameObject themepanel;
    public GameObject themetext;
    public GameObject sparks;
    void Start()
    {
       // Time.timeScale = 0;
        themetext.SetActive(false);
        themepanel.SetActive(true);
        sparks.SetActive(true);
        StartCoroutine(ThemeActive());
    }

    public IEnumerator ThemeActive()
    {
        yield return new WaitForSeconds(2f);
        sparks.SetActive(false);
        yield return new WaitForSeconds(2f);
        themetext.SetActive(true);
        themepanel.SetActive(false);

       // Time.timeScale = 1;
    }
}
