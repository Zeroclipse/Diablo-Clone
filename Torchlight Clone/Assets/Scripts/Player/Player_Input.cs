using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player_Input : MonoBehaviour
{
    private bool inventoryOpen = false;
    public SetupInventory setup;
    public event Action OnInventoryPress = delegate { };
    public event Action OnEscPress = delegate { };
    void Update()
    {
        if (Input.GetButtonDown("InventoryButton") || inventoryOpen == true && Input.GetButtonDown("Escape"))
        {
            OnInventoryPress();
            if (inventoryOpen == false)
            {
                inventoryOpen = true;
            }
            else
            {
                inventoryOpen = false;
            }
        }

        if (inventoryOpen == false && Input.GetButtonDown("Escape"))
        {
            OnEscPress();
        }

        if (inventoryOpen == true)
        {
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
        }
    }
}
