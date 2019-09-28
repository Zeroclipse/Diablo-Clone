using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class InventoryClick : MonoBehaviour
{
    #region Variables
    private SetupInventory steal;  //Holds the SetupInventory Script
    private EquipClick equip; //Holds the EquipClick Script

    private List<Items> itemList; //Holds the entire itemList
    private Image[] Inventory; //Holds an array of the items in the Inventory
    private Image[] Equipment; //Holds an array of the equipment in the inventory

    private int itemNumber; //The number of the item when it's picked
    private int nameint; //The name of the button when it's picked
    private int tint; //The tint of the item when it's picked

    public Sprite tempSprite;
    public Color tempColor;

    private AudioSource cameraAudio; //Audio Source Component for the camera
    private AudioClip failSound; //Audioclip for failure
    private AudioClip correctSound; //Audioclip for success
    #endregion
    #region Setup
    private void Awake()
    {
        //Initializes variables to their respective components
        steal = GetComponent<SetupInventory>();
        equip = GetComponent<EquipClick>();
        cameraAudio = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        failSound = Resources.Load<AudioClip>("Sounds/Inventory/Hit_Hurt");
        correctSound = Resources.Load<AudioClip>("Sounds/Inventory/Blip_Select");
    }
    private void Start()
    { 
        //Initializes arrays and List to the created list from the SetupInventory Script
        itemList = steal.itemList;
        Inventory = steal.Inventory;
        Equipment = steal.Equipment;
    }
    #endregion
    #region Select Inventory Item
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
                                    cameraAudio.clip = failSound;
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
    #endregion
    #region Destroy Inventory Item
    public void _DestroyInventory(Image button)
    {
        //If nothing is selected from the equipment side
        if (equip.equipSelected == false)
        {
            //If left shift is being held down
            if (Input.GetKey(KeyCode.LeftShift))
            {
                //Gets the name of the button which is a number, er the image that's a number under the button
                int nameint = Convert.ToInt32(button.gameObject.name);
                //Uses that int to Load the black sprite
                Inventory[nameint].sprite = Resources.Load<Sprite>("Assets/Images/annexation.png");
                //Changes the color to black
                Inventory[nameint].color = Color.black;
                //Changes the tint to 0
                steal.itemList[nameint].tint = 0;
                //Changes the item to 0
                steal.itemList[nameint].item = 0;
                //Calls the Compress method
                steal.Compress();
            }
        }
    }
    #endregion
}