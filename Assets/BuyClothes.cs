using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuyClothes : MonoBehaviour
{
    public InventoryObject playerWardrobe;
    public InventoryObject shopStorage;

    public ItemDatabaesObject itemDatabaes;
    public GameObject clothesItem;

    public ItemViewer IV;
    public ShopInterface Shop;

    public BankApp bankBalance;
   // public float MoneyLeft;

    public TMP_Text funds;

    void Start()
    {
        clothesItem = null;
      //  MoneyLeft = bankBalance.balance;
    }

    private void Update()
    {
      //  MoneyLeft = bankBalance.balance;
        if (IV.clotheItem != null)
        {
            clothesItem = IV.clotheItem.gameObject;
        }
    }
    public void OnBuy(ItemObject newItemBuy)
    {
        if (bankBalance.balance >= IV.price)
        {
            Debug.Log($"Buy {IV.id}");
            bankBalance.balance -= IV.price;
            playerWardrobe.AddItem(new Item(newItemBuy), 1);
            shopStorage.RemoveItem(new Item(newItemBuy));
            Shop.DestroySlot(IV.id);
            IV.DestroyItem();
        }
        else
        {
            StartCoroutine(fundsVisable());
        }
    }

    public void Buy()
    {      
        OnBuy(itemDatabaes.ItemsObjects[IV.id]);
    }

    IEnumerator fundsVisable()
    {
        funds.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        funds.gameObject.SetActive(false);
    }

}
