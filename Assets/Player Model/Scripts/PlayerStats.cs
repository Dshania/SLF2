using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerStats : MonoBehaviour
{
    public UnityEvent<float> UpdatePoints;

    public Attribute[] attributes;

    private InventoryObject outfit;

    public TMP_Text scoreText;
    public float scoreTotal;

    public ScoreSystem scoreSystem; 

   // public Animator particleAnimator;
    public ParticleSystem spiralPart;
    // public List<int> scoreList = new List<int>();
    void Start()
    {
        outfit = GetComponent<Player>().outfit;

        PlayerPrefs.SetString("Score", "0");
        PlayerPrefs.SetFloat("Scores", 0);

        for (int i = 0; i < attributes.Length; i++)
        {
            attributes[i].SetParent(this);
        }

        for (int i = 0; i < outfit.GetSlots.Length; i++)
        {
            outfit.GetSlots[i].OnBeforeUpdate += OnRemoveItem;
            outfit.GetSlots[i].OnAfterUpdate += OnEquipItem;
        }
    }

    public void AttributeModified(Attribute attribute)
    {
        Debug.Log(string.Concat(attribute.type, "was uodated and now is ...", attribute.value.ModifiedValue));
        UpdatePoints.Invoke(attribute.value.ModifiedValue);

        scoreText.text = attribute.value.ModifiedValue.ToString();
        scoreTotal = attribute.value.ModifiedValue;
        PlayerPrefs.SetString("Score", scoreText.text);
        PlayerPrefs.SetFloat("Scores", scoreTotal);
        PlayerPrefs.Save();
        // scoreList.Add((int)scoreTotal);
        scoreSystem.levelScore = scoreTotal;
        scoreSystem.TotalScore = scoreTotal;

    }

    public void OnRemoveItem(InventorySlot slot)
    {
        if (slot.ItemObject == null)
            return;

     //   particleAnimator.SetTrigger("clothesOffPart"); 

        switch (slot.parent.inventory.type)
        {
            case InterfaceType.Inventory:
                print("clothes removed on: " + slot.parent.inventory.type + ", Allowed items: " +
                        string.Join(", ", slot.AllowedItems));
                break;

            case InterfaceType.Outfit:

                for (int i = 0; i < slot.item.buffs.Length; i++)
                {
                    for (int j = 0; j < attributes.Length; j++)
                    {
                        if (attributes[j].type == slot.item.buffs[i].attribute)
                            attributes[j].value.RemoveModifier(slot.item.buffs[i]);
                    }
                }
                break;
            default:
                break;
        }
    }

    public void OnEquipItem(InventorySlot slot)
    {
        if (slot.ItemObject == null)
            return;

     //   particleAnimator.SetTrigger("clothesDropPart");
        spiralPart.Play();

        switch (slot.parent.inventory.type)
        {
            case InterfaceType.Inventory:
                print("clothes placed on: " + slot.parent.inventory.type + ", Allowed items: " +
                     string.Join(", ", slot.AllowedItems));
                break;

            case InterfaceType.Outfit:

                for (int i = 0; i < slot.item.buffs.Length; i++)
                {
                    for (int j = 0; j < attributes.Length; j++)
                    {
                        if (attributes[j].type == slot.item.buffs[i].attribute)
                            attributes[j].value.AddModifier(slot.item.buffs[i]);
                    }
                }
                break;

            default:
                break;
        }
    }

/*    public void Reset()
    {
        PlayerPrefs.DeleteAll();
    }*/
}

