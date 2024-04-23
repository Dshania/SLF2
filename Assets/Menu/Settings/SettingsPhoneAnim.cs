using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SettingsPhoneAnim : MonoBehaviour
{
    public float speed;
    private IEnumerator vibrate;
    private Vector3 startPos;
    private bool canVibrate;
    public AudioSource vibrationSFX;
    private void Start()
    {
        startPos = new Vector3(960, 540, 0);
        canVibrate = true;
    }

    void Update()
    {
        Vector3 targetPosition = new Vector3(960,540, 0);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        StartCoroutine(phoneShake());
    }

    IEnumerator phoneShake()
    {
        yield return new WaitForSeconds(5);

          if (canVibrate)
          {
            phoneRing();
          }
       
    }

    private void phoneRing()
    {
        canVibrate = false;
        vibrate = Vibrating();
        StartCoroutine(vibrate);
        Invoke("StopRing", 1f);
    }

    private void StopRing()
    {
        StopCoroutine(vibrate);
        StartCoroutine(Waiting());
        vibrationSFX.Stop();
        
/*        transform.position = startPos;
        canVibrate = true;*/
    }

    private IEnumerator Vibrating()
    {
        vibrationSFX.Play();
        canVibrate = false;
        while (true)
        {

            float offsetX = Random.Range(-15, 15f);
            float offsetY = Random.Range(-5f, 5f);

            transform.position = new Vector3(transform.position.x + offsetX, transform.position.y + offsetY, 0f);

            yield return new WaitForSeconds(0.01f);

            transform.position = startPos;
        }

    }

    private IEnumerator Waiting()
    {
        transform.position = startPos;
        yield return new WaitForSeconds(3f);
        canVibrate = true;
    }

}
