using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class Player : MonoBehaviour
{

    public InventoryObject inventory;
    public InventoryObject outfit;

    public void OnTriggerEnter(Collider other)
    {
        var item = other.GetComponent<GroundItem>();
        if (item)
        {
            if (inventory.AddItem(new Item(item.item), 1))
            {
                Destroy(other.gameObject);
            }
        }
    }

    public void Update()
    {
/*        if (Input.GetKey(KeyCode.S))
        {
            inventory.Save();
            outfit.Save();
        }
        else if (Input.GetKey(KeyCode.L))
        {
            inventory.Load();
            outfit.Load();
        }*/
    }

    private void OnApplicationQuit()
    {
        inventory.Clear();
        outfit.Clear();
    }
}
