using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemViewer : MonoBehaviour, IDragHandler
{
    public Transform clotheItem;

    public void OnDrag(PointerEventData eventData)
    {
        if (clotheItem != null)
        {
            clotheItem.transform.eulerAngles += new Vector3(-eventData.delta.y, -eventData.delta.x);
        }
    }
}
