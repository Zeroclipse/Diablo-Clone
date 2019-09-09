using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearEquip : MonoBehaviour
{
    private EquipClick equip;
    private InventoryClick invent;
    public Image[] buttons;

    private void Awake()
    {
        equip = GameObject.Find("Main Camera").GetComponent<EquipClick>();
        invent = GameObject.Find("Main Camera").GetComponent<InventoryClick>();
    }

    private void OnDisable()
    {
        foreach (Image button in buttons)
        {
            button.color = Color.white;
        }
            equip.equipSelected = false;
            invent.equipSelected = false;
    }
}
