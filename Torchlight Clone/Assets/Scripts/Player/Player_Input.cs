using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player_Input : MonoBehaviour
{
    private bool inventoryOpen = false;
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
    }
}
