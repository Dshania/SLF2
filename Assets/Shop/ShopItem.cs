
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
    public Image image;
    public TMP_Text textPrice;
   [SerializeField] private GameObject saleItem;

    public void LoadNewItem(ItemObject newItem)
    {
        currentItem = newItem;
        image = transform.GetChild(0).GetComponent<Image>();
        textPrice.text = "£ " + currentItem.price.ToString();
        saleItem = transform.GetChild(0).GetComponent<GameObject>();
        DisplayItemIMG();
    }

    private void DisplayItemIMG()
    {
        image.sprite = currentItem.uiDisplay;
       
    }
    public void LoadClothes(ItemObject newItemOBJ, ItemViewer itemViewer, int id)
    {
        if (itemViewer.clotheItem != null)
        {
            Destroy(itemViewer.clotheItem.gameObject);
        }
        currentItem = newItemOBJ;
        Transform item = DisplayItemOBJ();
        itemViewer.clotheItem = item.transform;
        itemViewer.id = id;
        itemViewer.price = newItemOBJ.price;
        Debug.Log(newItemOBJ.name);
    }

    public Transform DisplayItemOBJ()
    {
        saleItem = currentItem.characterDisplay;
        SkinnedMeshRenderer skin = saleItem.GetComponent<SkinnedMeshRenderer>();
        GameObject obj = new GameObject();
        obj.name = skin.name;
        MeshRenderer renderer = obj.AddComponent<MeshRenderer>();
        MeshFilter filter = obj.AddComponent<MeshFilter>();
        filter.mesh = skin.sharedMesh;
        renderer.material = skin.sharedMaterial;
        obj.transform.position = new Vector3(0, 0, 0);
        return obj.transform;

    }
}
