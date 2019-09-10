using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryClick : MonoBehaviour
{
    public int name;
    public int tint;
    public List<Items> itemList;
    public EquipClick equip;
    public Sprite tempSprite;
    public Color tempColor;
    public Image[] Inventory;
    public Image[] Equipment;
    public SetupInventory steal;

    private AudioSource cameraAudio;
    public AudioClip selectSound;
    private void Awake()
    {
        steal = GetComponent<SetupInventory>();
        Inventory = steal.Inventory;
        Equipment = steal.Equipment;
        equip = GetComponent<EquipClick>();
        itemList = new List<Items>();
        foreach (Image item in Inventory)
        {
            Items newItem = new Items();
            itemList.Add(newItem);
        }
        foreach (Image item in Equipment)
        {
            Items newItem = new Items();
            itemList.Add(newItem);
        }
        cameraAudio = this.gameObject.GetComponent<AudioSource>();
    }
    public void _SelectEquippedItem(Image button)
    {
        if (equip.equipSelected == true)
        {
            for (int i = 0; i < Equipment.Length; i++)
            {
                if (Equipment[i].transform.parent.GetComponent<Image>().color == Color.red)
                {
                    name = Convert.ToInt32(button.gameObject.name);
                    for (int j = 0; j < Inventory.Length; j++)
                    {
                        if(itemList[j] == itemList[(name)])
                        {
                            if (itemList[j].item == itemList[i].item)
                            {
                                tempSprite = button.sprite;
                                tempColor = button.color;
                                button.sprite = Equipment[i].sprite;
                                button.color = Equipment[i].color;
                                Equipment[i].sprite = tempSprite;
                                Equipment[i].color = tempColor;
                                tint = itemList[j].tint;
                                itemList[j].tint = itemList[i + 9].tint;
                                itemList[i + 9].tint = tint;
                                Equipment[i].transform.parent.GetComponent<Image>().color = Color.white;
                            }
                            else if (itemList[j].item != itemList[i].item)
                            {
                                cameraAudio.clip = selectSound;
                                cameraAudio.Play();

                                Equipment[i].transform.parent.GetComponent<Image>().color = Color.white;
                            }
                        }
                    }
                }
            }
        }
    }
}
