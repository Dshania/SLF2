using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class TextEffect : MonoBehaviour
{
    public float moveTime;
    public float speed;
    private Vector3 moveDirection;
    public TextMeshProUGUI textMeshPro;

    private void Start()
    {
        StartCoroutine(RandomMovement());
    }

    private IEnumerator RandomMovement()
    {
        moveDirection = UnityEngine.Random.insideUnitCircle.normalized;
        float timeLeft = 0f;

        while (timeLeft < moveTime)
        {
            transform.Translate(moveDirection * speed * Time.deltaTime);
            timeLeft += Time.deltaTime;
            yield return null;
        }
        RestartTime();
    }

    private void RestartTime()
    {
        moveTime = 2f;
        StartCoroutine(RandomMovement());
    }
}