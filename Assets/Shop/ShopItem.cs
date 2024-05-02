
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using Unity.VisualScripting;
using UnityEngine.EventSystems;

public class ShopItem : MonoBehaviour
{
    public ItemObject currentItem;
    private Image image;
    private TMP_Text textPrice;
    private GameObject saleItem;

    void Awake()
    {
        image = transform.GetChild(0).GetComponent<Image>();
        textPrice.text = "£ " + currentItem.price.ToString();
        saleItem = transform.GetChild(0).GetComponent<GameObject>();
    }

    public void LoadNewItem(ItemObject newItem)
    {
        currentItem = newItem;
        DisplayItemIMG();
    }

    private void DisplayItemIMG()
    {
        image.sprite = currentItem.uiDisplay;
       
    }
    public void LoadClothes(ItemObject newItemOBJ)
    {
        currentItem = newItemOBJ;
        DisplayItemOBJ();
        Debug.Log(newItemOBJ.name);
    }

    public void DisplayItemOBJ()
    {
        saleItem = currentItem.characterDisplay;
        Quaternion rotation = Quaternion.Euler(0, 180, 0);

        if (saleItem != null)
        {
            Destroy(saleItem);
        }
        GameObject obj = Instantiate(saleItem, new Vector3(1000, 1000, 1000), rotation);
        obj.transform.AddComponent<ItemViewer>();
    }
}
