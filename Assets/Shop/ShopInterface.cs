using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class ShopInterface : UserInterface
{
    public ItemViewer itemViewer;
    public GameObject ShopInventoryPrefab;
    public ItemDatabaesObject database;
    public int X_Start;
    public int Y_Start;
    public int X_Space;
    public int Number_Of_Columns;
    public int Y_Space;
    public override void CreateSlots()
    {
        slotsOnInterface = new Dictionary<GameObject, InventorySlot>();

        for (int i = 0; i < inventory.Container.Slots.Length; i++)
        {
            var obj = Instantiate(ShopInventoryPrefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);

            int id = inventory.Container.Slots[i].item.Id;
            obj.GetComponent<ShopItem>().LoadNewItem(database.ItemsObjects[id]);

            obj.transform.GetComponent<Button>().onClick.AddListener(() => obj.GetComponent<ShopItem>().LoadClothes(database.ItemsObjects[id], itemViewer));

             AddEvent(obj, EventTriggerType.PointerEnter, delegate { OnEnter(obj); });
             AddEvent(obj, EventTriggerType.PointerExit, delegate { OnExit(obj); });
             AddEvent(obj, EventTriggerType.Select, delegate { OnSelect(obj); });
        }
    }

    private Vector3 GetPosition(int i)
    {
        return new Vector3(X_Start + (X_Space * (i % Number_Of_Columns)), Y_Start + (-Y_Space * (i / Number_Of_Columns)), 0f);
    }

}
