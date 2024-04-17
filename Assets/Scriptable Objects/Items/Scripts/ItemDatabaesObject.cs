using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = " New Item Database", menuName = "Inventory System/Items/Databases")]
public class ItemDatabaesObject : ScriptableObject, ISerializationCallbackReceiver
{
    public List<ItemObject> ItemsObjects;
    //public Dictionary<int, ItemObject> GetItem = new Dictionary<int, ItemObject>();

    [ContextMenu("Update ID's")]
    public void UpdateID()
    {
        for (int i = 0; i < ItemsObjects.Count; i++)
        {
            if(ItemsObjects[i].data.Id != i)
                ItemsObjects[i].data.Id = i;
        }
    }
    public void OnAfterDeserialize()
    {
        UpdateID();
    }

    public void OnBeforeSerialize()
    {
        //GetItem = new Dictionary<int, ItemObject>();
    }
}
