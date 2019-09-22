using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class InventoryClick : MonoBehaviour
{
    public int nameint;
    public int tint;
    public List<Items> itemList;
    public EquipClick equip;
    public Sprite tempSprite;
    public Color tempColor;
    public Image[] Inventory;
    public Image[] Equipment;
    public SetupInventory steal;
    public int itemNumber;

    private AudioSource cameraAudio;
    public AudioClip selectSound;
    public AudioClip correctSound;
    private void Awake()
    {
        steal = GetComponent<SetupInventory>();
        Inventory = steal.Inventory;
        Equipment = steal.Equipment;
        equip = GetComponent<EquipClick>();
        itemList = steal.itemList;
        cameraAudio = this.gameObject.GetComponent<AudioSource>();
    }
    public void _SelectEquippedItem(Image button)
    {
        if (equip.equipSelected == true)
        {
            if (!Input.GetKey(KeyCode.LeftShift))
            {
                for (int i = 0; i < Equipment.Length; i++)
                {
                    if (Equipment[i].transform.parent.GetComponent<Image>().color == Color.red)
                    {
                        nameint = Convert.ToInt32(button.gameObject.name);
                        for (int j = 0; j < Inventory.Length; j++)
                        {
                            if (steal.itemList[j] == steal.itemList[nameint])
                            {
                                if (steal.itemList[j].item == steal.itemList[i + 9].item)
                                {
                                    tempSprite = button.sprite;
                                    tempColor = button.color;

                                    button.sprite = Equipment[i].sprite;
                                    button.color = Equipment[i].color;

                                    Equipment[i].sprite = tempSprite;
                                    Equipment[i].color = tempColor;
                                    tint = steal.itemList[j].tint;

                                    steal.itemList[j].tint = steal.itemList[i + 9].tint;
                                    steal.itemList[i + 9].tint = tint;

                                    cameraAudio.clip = correctSound;
                                    cameraAudio.Play();
                                }
                                else if (steal.itemList[j].item != steal.itemList[i + 9].item)
                                {
                                    Debug.Log(steal.itemList[j].item + " " + steal.itemList[i + 9].item);
                                    cameraAudio.clip = selectSound;
                                    cameraAudio.Play();
                                }
                            }
                        }
                        equip.equipSelected = false;
                        Equipment[i].transform.parent.GetComponent<Image>().color = Color.white;
                    }
                }
            }
        }
    }

    public void _DestroyInventory(Image button)
    {
        if (equip.equipSelected == false)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                for (int i = 0; i < Inventory.Length; i++)
                {
                    nameint = Convert.ToInt32(button.gameObject.name);
                    if (steal.itemList[i] == steal.itemList[nameint])
                    {
                        Inventory[i].sprite = Resources.Load<Sprite>("Assets/Images/annexation.png");
                        Inventory[i].color = Color.black;

                        steal.itemList[i].tint = 0;

                        steal.itemList[i].item = 0;
                    }
                }
                steal.Compress();
            }
        }
    }
}