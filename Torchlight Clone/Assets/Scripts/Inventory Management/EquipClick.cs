using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipClick : MonoBehaviour
{
    public bool equipSelected = false;

    public void _SelectEquippedItem(Image button)
    {
        if (equipSelected == false)
        {
            button.color = Color.red;
            equipSelected = true;
        }
        else
        {
            if (button.color == Color.red)
            {
                equipSelected = false;
                button.color = Color.white;
            }
        }
    }
}
