using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardApp : MonoBehaviour
{
    public GameObject LB;
    public GameObject AppScreen;

    public void CloseLB()
    {
        LB.SetActive(false);
        AppScreen.SetActive(true);
    }
}
