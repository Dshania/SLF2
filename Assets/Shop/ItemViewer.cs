using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemViewer : MonoBehaviour, IDragHandler
{
    public Transform clotheItem;
    public int id;
    public float price;

    public void OnDrag(PointerEventData eventData)
    {
        if (clotheItem != null)
        {
            clotheItem.transform.eulerAngles += new Vector3(0, -eventData.delta.x);
        }
    }

    internal void DestroyItem()
    {
        Destroy(clotheItem.gameObject);
    }
}
