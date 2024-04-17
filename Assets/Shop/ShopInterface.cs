using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using static System.Collections.Specialized.BitVector32;
using static UnityEditor.Progress;
using UnityEngine.UI;

public class ShopInterface : UserInterface
{
    // public GameObject[] slots;
    public GameObject ShopInventoryPrefab;
    public int X_Start;
    public int Y_Start;
    public int X_Space;
    public int Number_Of_Columns;
    public int Y_Space;
  //  public InventorySlot shopslot;
    public override void CreateSlots()
    {
        slotsOnInterface = new Dictionary<GameObject, InventorySlot>();

        for (int i = 0; i < inventory.Container.Slots.Length; i++)
        {
            /*         for (int j = 0; j < slots.Length; j++)
                     {
                         var obj = slots[j];
                         slots[j].GetComponent<RectTransform>().localPosition = GetPosition();
                     }*/
            var obj = Instantiate(ShopInventoryPrefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);

            AddEvent(obj, EventTriggerType.PointerEnter, delegate { OnEnter(obj); });
            AddEvent(obj, EventTriggerType.PointerExit, delegate { OnExit(obj); });
            AddEvent(obj, EventTriggerType.BeginDrag, delegate { OnDragStart(obj); });
            AddEvent(obj, EventTriggerType.EndDrag, delegate { OnDragEnd(obj); });
            AddEvent(obj, EventTriggerType.Drag, delegate { OnDrag(obj); });
            AddEvent(obj, EventTriggerType.Select, delegate { OnSelect(obj); });

            inventory.GetSlots[i].slotDisplay = obj;

            slotsOnInterface.Add(obj, inventory.Container.Slots[i]);
/*
            if (shopslot.item.Id > 0)
            {
                shopslot.slotDisplay.transform.GetChild(0).GetComponentInChildren<Image>().sprite = shopslot.ItemObject.uiDisplay;
            }*/
        }
    }

    private Vector3 GetPosition(int i)
    {
        return new Vector3(X_Start + (X_Space * (i % Number_Of_Columns)), Y_Start + (-Y_Space * (i / Number_Of_Columns)), 0f);
    }

    public void itemSelected()
    {
        Debug.Log(gameObject.name);

    }
}
