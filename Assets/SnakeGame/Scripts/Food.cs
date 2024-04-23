using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public BoxCollider2D gridArea;
    [SerializeField] AudioClip[] biteSounds;
    public AudioSource biteSFX;

    private void Start()
    {
        RandomPosition();
        biteSFX = GetComponent<AudioSource>();
    }
    private void RandomPosition()
    {
        RandomSound();
        Bounds bounds = this.gridArea.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Snake")
        {
            RandomPosition();
        }
        else if (other.tag == "Barrier")
        {
            RandomPosition();
        }
    }

    public void RandomSound()
    {
      AudioClip clip = biteSounds[UnityEngine.Random.Range(0, biteSounds.Length)];
        biteSFX.PlayOneShot(clip);
    }
}
