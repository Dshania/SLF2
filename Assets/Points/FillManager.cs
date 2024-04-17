using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;


public class FillManager : MonoBehaviour
{
    [SerializeField]
    GameObject[] gameObjects;

    //public float _Fill_Height;

    public Color fillColour;
    public Color defaultColour;

    private Material fillMaterial;


    void Start()
    {
        fillMaterial = GetComponent<Renderer>().material;
    }

    public void PointsUpdate(float fillValue)
    {
        foreach (GameObject go in gameObjects)
        {
            fillMaterial.SetFloat("_Fill_Height", fillValue);
        }
    }

}
