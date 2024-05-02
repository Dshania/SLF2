using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemViewer : MonoBehaviour, IDragHandler
{
    public Transform clotheItem;

    private void Start()
    {
        clotheItem = GetComponent<Transform>();
    }
    public void OnDrag(PointerEventData eventData)
    {
       gameObject.transform.eulerAngles += new Vector3(-eventData.delta.y, -eventData.delta.x);
    }
}
