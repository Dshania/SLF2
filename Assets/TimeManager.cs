using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField]
    GameObject[] gameObjects;

    //public float _Fill_Height;

    public Color fillColour;
    public Color defaultColour;
    public float LevelTime;

    private Material fillMaterial;


    void Start()
    {
        fillMaterial = GetComponent<Renderer>().material;
        TimeUpdate(LevelTime);
    }
    void Update()
    {
        LevelTime -= Time.deltaTime;
        if (LevelTime < 0)
        {
            LevelTime = 0;
        }
 /*       if (LevelTime < 0)
        {
          
        }
       else if (LevelTime > 0)
        {
            LevelTime = 0;
    GameOver();
        }*/
    }

    public void TimeUpdate(float TimeValue)
    {
        foreach (GameObject go in gameObjects)
        {
            fillMaterial.SetFloat("_Fill_Height", TimeValue);
        }
    }
}
