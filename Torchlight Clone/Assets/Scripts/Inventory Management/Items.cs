using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Items
{
    public int item;
    public int tint;

    public Items()
    {
        item = 0;
        tint = 0;
    }


    public void EnterItems(int itement)
    {
        item = itement;

        tint = Random.Range(1, 5);
    }
}
