using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearEquip : MonoBehaviour
{
    private EquipClick equip;
    public Image[] buttons;

    private void Awake()
    {
        equip = GameObject.Find("Main Camera").GetComponent<EquipClick>();
    }

    private void OnDisable()
    {
        foreach (Image button in buttons)
        {
            button.color = Color.white;
        }
            equip.equipSelected = false;
    }
}
