using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerRotate : MonoBehaviour, IDragHandler
{
    public Transform PlayerTrans;
    public void OnDrag(PointerEventData eventData)
    {
        PlayerTrans.eulerAngles += new Vector3(0, -eventData.delta.y);

        Debug.Log("onDragPlayer");
    }

}
