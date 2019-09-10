using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class DeleteInvent : MonoBehaviour
{
    public int name;
    public int item;
    public Image[] Inventory;
    public List<Items> itemList;
    public SetupInventory steal;

    public void Awake()
    {
        steal = GetComponent<SetupInventory>();
        Inventory = steal.Inventory;
        itemList = new List<Items>();
        foreach (Image item in Inventory)
        {
            Items newItem = new Items();
            itemList.Add(newItem);
        }
    }
    public void _DeleteEquippedItem(Image button)
    {
        name = Convert.ToInt32(button.gameObject.name);
        if (Input.GetKey(KeyCode.LeftShift))
        {
           for (int i = 0; i < Inventory.Length; i++)
            {
                //Check through itemList to save the item
                //Reset the inventory data for the item
                //Maybe do more
                //if (itemList[i] == itemList[name])
            }
        }

    }
}
