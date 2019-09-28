using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check_Inventory : MonoBehaviour
{
    #region Variables
    //variable to decide what to do, open or close the inventory
    private bool inventoryOpen = false;
    //Object that holds the inventory Screen
    [SerializeField]private GameObject inventoryScreen;
    //Variable that holds the player Input component
    private Player_Input playerInput;
    #endregion

    #region Set up
    private void Awake()
    {
        //Find the PlayerInput component
        playerInput = GameObject.Find("Main Camera").GetComponent<Player_Input>();

        //Subscription here
        playerInput.OnInventoryPress += InventoryCheck;
    }

    private void Start()
    {
        inventoryOpen = playerInput.inventoryOpen;
        //Disables the inventoryScreen if inventoryOpen is false
        if (inventoryOpen == false)
        {
            inventoryScreen.SetActive(false);
        }
        //Else it makes sure that it's open
        else
        {
            inventoryScreen.SetActive(true);
        }
    }
    #endregion

    #region Inventory Check
    //Open or Close Inventory
    public void InventoryCheck()
    {
        //Opens the inventory Screen
        if (inventoryOpen == false)
        {
            inventoryScreen.SetActive(true);
            inventoryOpen = true;
        }

        //Closes the inventory Screen
        else
        {
            inventoryScreen.SetActive(false);
            inventoryOpen = false;
        }
    }
    #endregion
}
