using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class TextMover : MonoBehaviour
{
    public float speed;
    public float size;
    private Vector3 startPos;
    private float startTime;

    void Start()
    {
        startPos = transform.position;
        startTime = Time.time;
    }

    void Update()
    {
        float time = (Time.time - startTime) * speed;
        float x = Mathf.Sin(time) * size + startPos.x;
        float y = Mathf.Cos(time) * size + startPos.y;
        transform.position = new Vector3(x, y, startPos.z);
    }
}
