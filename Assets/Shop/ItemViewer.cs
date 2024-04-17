using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemViewer : MonoBehaviour
{
    [SerializeField] private ShopInterface shopInventory;

    private void Start()
    {
        //shopInventory.OnSelected += ShopInventoryItemSelected;
    }

    private void ShopInventoryItemSelected(object sender, ItemObject item)
    {
        Debug.Log(item.name);
    }
}
