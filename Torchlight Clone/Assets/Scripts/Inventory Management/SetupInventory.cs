using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetupInventory : MonoBehaviour
{
    public List<Items> itemList;
    public int randomNumber;
    public Image[] Inventory;
    public Image[] Equipment;

    private void Awake()
    {
        itemList = new List<Items>();
        //Temporary

        foreach (Image item in Inventory)
        {
            Items newItem = new Items();
            itemList.Add(newItem);
        }

        for (int i = 0; i <= itemList.Count; i++)
        {
            itemList[i].EnterItem(Random.Range(1, 6));
            if(itemList[i].item == 1)
            {
                randomNumber = Random.Range(1, 5);
                //Finish
                if (randomNumber = 1)
                {
                    //Use Asset Database
                    Inventory[i].Sprite = "brutal-helm";
                }
            }
        }
    }
}
