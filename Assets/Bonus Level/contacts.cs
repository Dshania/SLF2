using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class contacts : MonoBehaviour
{
    public GameObject contactsApp;
    public GameObject AppScreen;

    public void CloseContacts()
    {
        contactsApp.SetActive(false);
        AppScreen.SetActive(true);
    }
}
