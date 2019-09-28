using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player_Input : MonoBehaviour
{
    #region Variables and Delegates
    //This is just to check if the inventory is open or closed
    public bool inventoryOpen;

    //Delete this, this is just for setting up the inventory
    public SetupInventory setup;

    //Sends when you click the inventory button, which is i
    public event Action OnInventoryPress = delegate { };
    //sends when you press escape
    public event Action OnEscPress = delegate { };
    #endregion
    void Update()
    {
        #region Open and Close Inventory
        //Check if you want to close the inventory
        if (Input.GetButtonDown("InventoryButton") || inventoryOpen == true && Input.GetButtonDown("Escape"))
        {
            //Calls the delegate that has the method to open or close the inventory
            OnInventoryPress();
            //Switches inventory open to true or false
            if (inventoryOpen == false)
            {
                inventoryOpen = true;
            }
            else
            {
                inventoryOpen = false;
            }
        }
        #endregion
        #region Escape
        if (inventoryOpen == false && Input.GetButtonDown("Escape"))
        {
            OnEscPress();
        }
        #endregion
        if (inventoryOpen == true)
        {
            #region Temporary Test Things for Inventory
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                setup.Place1();
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                setup.Place2();
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                setup.Place3();
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                setup.Place4();
            }
            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                setup.Place5();
            }
            #endregion
        }
        else
        {

        }
    }
}
