using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditor.Timeline.Actions.MenuPriority;

public class PlayeEquip : MonoBehaviour
{
    private InventoryObject inventory;

    private MeshCombiner meshCombiner;

    private Transform hair;
    private Transform top;
    private Transform bottom;
    private Transform shoes;

    /* [SerializeField]
     private Transform hairTransform;*/
    void Start()
    {
        //outfit = GetComponent<InventoryObject>();
        inventory = GetComponent<Player>().outfit;

        meshCombiner = new MeshCombiner(gameObject);

        for (int i = 0; i < inventory.GetSlots.Length; i++)
        {
            inventory.GetSlots[i].OnBeforeUpdate += OnRemoveItem;
            inventory.GetSlots[i].OnAfterUpdate += OnAddItem;
        }
    }

    public void OnAddItem(InventorySlot _slot)
    {
        var itemObject = _slot.ItemObject;
        //slot.GetItemObject();
        if (itemObject == null)
            return;
        switch (_slot.parent.inventory.type)
        {
          
            case InterfaceType.Outfit:


                if (itemObject.characterDisplay != null)
                {
                    switch (_slot.AllowedItems[0])
                    {
                        case ItemType.Hair:
                            // hair = Instantiate(itemObject.characterDisplay, hairTransform).transform;
                            hair = meshCombiner.AddLimb(itemObject.characterDisplay, itemObject.boneNames);
                            break;

                        case ItemType.Top:
                            top = meshCombiner.AddLimb(itemObject.characterDisplay, itemObject.boneNames);
                            break;

                        case ItemType.Bottom:
                            bottom = meshCombiner.AddLimb(itemObject.characterDisplay, itemObject.boneNames);
                            break;

                        case ItemType.Shoes:
                            shoes = meshCombiner.AddLimb(_slot.ItemObject.characterDisplay, _slot.ItemObject.boneNames);
                            break;
                    }
                }
/*                break;
            case InterfaceType.Shop:
                break;*/
                break;
        }
    }

    public void OnRemoveItem(InventorySlot _slot)
    {
        if (_slot.ItemObject == null)
            return;

        switch (_slot.parent.inventory.type)
        {
            case InterfaceType.Outfit:

                if (_slot.ItemObject.characterDisplay != null)
                {
                    switch (_slot.AllowedItems[0])
                    {
                        case ItemType.Hair:
                            Destroy(hair.gameObject);
                            break;

                        case ItemType.Top:
                            Destroy(top.gameObject);
                            break;

                        case ItemType.Bottom:
                            Destroy(bottom.gameObject);
                            break;

                        case ItemType.Shoes:
                            Destroy(shoes.gameObject);
                            break;

                    }
                }
/*                break;
            case InterfaceType.Shop:
                break;
            default:*/
                break;
        }
    }


}
