
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
        textPrice.text = "� " + currentItem.price.ToString();
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
    public void LoadClothes(ItemObject newItemOBJ, ItemViewer itemViewer)
    {
        currentItem = newItemOBJ;
        Transform item = DisplayItemOBJ();
        itemViewer.clotheItem = item.transform;
        Debug.Log(newItemOBJ.name);
    }

    public Transform DisplayItemOBJ()
    {
        saleItem = currentItem.characterDisplay;
        Quaternion rotation = Quaternion.Euler(0, 180, 0);

        if (saleItem != null)
        {
            Destroy(saleItem);
        }
        SkinnedMeshRenderer skin = saleItem.GetComponent<SkinnedMeshRenderer>();
        GameObject obj = new GameObject();
        obj.name = skin.name;
        MeshRenderer renderer = obj.AddComponent<MeshRenderer>();
        MeshFilter filter = obj.AddComponent<MeshFilter>();
        filter.mesh = skin.sharedMesh;
        renderer.material = skin.sharedMaterial;
        obj.transform.position = new Vector3(0, 0, 0);
        obj.transform.rotation = rotation;
        return obj.transform;
    }
}
