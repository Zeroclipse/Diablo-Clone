using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player_Input : MonoBehaviour
{
    #region Variables and Delegates
    //This is just to check if the inventory is open or closed
    public bool inventoryOpen; //This is permanent

    //This is just to check if the Dungeon Randomization Menu is open or closed
    public bool dungeonOpen;  //This all may be just temporary and is probably temporary, if so delete any instances of this or stuff that requires this

    //Delete this, this is just for setting up the inventory
    public SetupInventory setup;

    //Sends when you click the inventory button, which is i
    public event Action OnInventoryPress = delegate { }; //Needed
    //sends when you press escape
    public event Action OnEscPress = delegate { }; //Needed

    //Sends when you press G, opens dungeon management things
    public event Action OnGPress = delegate { }; //Delete later
    #endregion
    void Update()
    {
        #region Dungeon Randomization Test
        //Test Code for the Dungeon Management things
        if (Input.GetKeyDown(KeyCode.G) && inventoryOpen == false || inventoryOpen == false && Input.GetButtonDown("Escape") && dungeonOpen == true)
        {
            //Calls the delegate that has the method to open or close the Dungeon Menu
            OnGPress();
            //Switches Dungeon open to true or false
            if (dungeonOpen == false)
            {
                dungeonOpen = true;
            }
            else
            {
                dungeonOpen = false;
            }
        }
        #endregion
        #region Open and Close Inventory
        //Check if you want to close the inventory
        if (Input.GetButtonDown("InventoryButton") && dungeonOpen == false || inventoryOpen == true && Input.GetButtonDown("Escape") && dungeonOpen == false)
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
        if (inventoryOpen == false && dungeonOpen == false && Input.GetButtonDown("Escape"))
        {
            OnEscPress();
        }
        #endregion
        if (inventoryOpen == true && dungeonOpen == false)
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
        #region Test things for dungeon
        else if (dungeonOpen == true)
        {
            //Use this for the camera moving scripts, maybe make a method that this calls and can be commented out
        }
        #endregion
    }
}
