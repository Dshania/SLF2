using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class shopCrtlScript : MonoBehaviour
{
    public GameObject shop;
    public GameObject AppScreen;

    public GameObject loadingIMG;
    public GameObject loadScreen;
    public GameObject shopURL;
    public float SpinSpeed;
   
    public TextMeshProUGUI URLText;
    public float typingSpeed;
    private Coroutine displayURLCor;

    public GameObject url;

    private void Start()
    {
        typeWriteEffect();
    }
    void Update()
    {
        StartCoroutine(loadingScreen());
    }

    void typeWriteEffect()
    {
        string URLline = "htps://www.SplashLifesytleFashion.com/search?pglt=41&q=shop+lifestyle+store+front&cvid=ba6d419a34c845f29f42f095f482edfa&gs_lcrp=EgZjaHJvbWUyBggAEEUYOTIGCAEQABhAMgYIAhAAGEAyBggDEAAYQDIGCAQQABhAMgYIBRAAGEAyBggGEAAYQDIGCAcQABhAMgYICBAAGEDSAQgzNDY1ajBqMagCALACAA&FORM=ANNTA1&PC=ACTS";
        if (displayURLCor != null)
        {
            StopCoroutine(displayURLCor);
        }
        displayURLCor =
        StartCoroutine(DisplayURL(URLline));
    }

    IEnumerator loadingScreen()
    {
        yield return new WaitForSeconds(0.5f);
        spinningLoad();
        yield return new WaitForSeconds(4.5f);
        closeLoading();
    }

    void spinningLoad()
    {
        loadingIMG.transform.Rotate(-Vector3.forward * SpinSpeed * Time.deltaTime);
    }

    void closeLoading()
    {
        loadingIMG.SetActive(false);
        loadScreen.SetActive(false);
        shopURL.SetActive(false);
        url.SetActive(true);
    }
    public void CloseShop()
    {
        shop.SetActive(false);
        AppScreen.SetActive(true);
    }

    IEnumerator DisplayURL(string url)
    {
        URLText.text = "";

        foreach (char letter in url.ToCharArray())
        {
            URLText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
