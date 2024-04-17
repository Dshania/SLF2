using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class TimeAndDate : MonoBehaviour
{
    [SerializeField] TMP_Text currentTime;
    [SerializeField] TMP_Text currentDate;
    public GameObject settings;
    private void Start()
    {
        settings.SetActive(false);
    }
    void Update()
    {
        currentTime.text = DateTime.UtcNow.ToLocalTime().ToString("HH:mm");
        currentDate.text = DateTime.Now.ToLongDateString();
    }
}
