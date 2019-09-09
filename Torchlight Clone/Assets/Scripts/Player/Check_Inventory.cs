using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check_Inventory : MonoBehaviour
{
    private bool inventoryOpen = false;
    private GameObject inventoryScreen;
    private void Awake()
    {
        inventoryScreen = GameObject.Find("Inventory Screen");
        GetComponent<Player_Input>().OnInventoryPress += OpenInventory;
    }

    private void Start()
    {
        inventoryScreen.SetActive(false);
    }

    public void OpenInventory()
    {
        if (inventoryOpen == false)
        {
            inventoryScreen.SetActive(true);
            inventoryOpen = true;
        }

        else
        {
            inventoryScreen.SetActive(false);
            inventoryOpen = false;
        }
    }
}
