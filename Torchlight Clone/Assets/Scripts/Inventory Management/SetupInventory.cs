﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class SetupInventory : MonoBehaviour
{
    public List<Items> itemList;
    public int randomNumber;
    public Image[] Inventory;
    public Image[] Equipment;
    public Sprite tempSprite;
    public Color tempColor;
    public int tint;
    public int itemNumber;

    //Think about using this delegate when other methods want to call compressItems, maybe delete it
    public event System.Action compressItems = delegate { };

    private void Awake()
    {
        itemList = new List<Items>();
        //Temporary

        foreach (Image item in Inventory)
        {
            Items newItem = new Items();
            itemList.Add(newItem);
        }

        tint = Random.Range(1, 5);
        //Finish
        itemList[0].EnterItems(1, tint);
        itemList[1].EnterItems(2, tint);
        itemList[2].EnterItems(3, tint);
        itemList[3].EnterItems(4, tint);
        itemList[4].EnterItems(5, tint);
        randomNumber = Random.Range(1, 5);
        if (randomNumber == 1)
        {
            //Use Asset Database
            Inventory[0].sprite = Resources.Load<Sprite>("Images/Inventory/Helmets/brutal-helm");
        }

        if (randomNumber == 2)
        {
            //Use Asset Database
            Inventory[0].sprite = Resources.Load<Sprite>("Images/Inventory/Helmets/spartan-helmet");
        }

        if (randomNumber == 3)
        {
            //Use Asset Database
            Inventory[0].sprite = Resources.Load<Sprite>("Images/Inventory/Helmets/turban");
        }

        if (randomNumber == 4)
        {
            //Use Asset Database
            Inventory[0].sprite = Resources.Load<Sprite>("Images/Inventory/Helmets/viking-helmet");
        }
            randomNumber = Random.Range(1, 4);
            if (randomNumber == 1)
            {
                //Use Asset Database
                Inventory[1].sprite = Resources.Load<Sprite>("Images/Inventory/Chest/pirate-coat");
            }

            if (randomNumber == 2)
            {
                //Use Asset Database
                Inventory[1].sprite = Resources.Load<Sprite>("Images/Inventory/Chest/polo-shirt");
            }

            if (randomNumber == 3)
            {
                //Use Asset Database
                Inventory[1].sprite = Resources.Load<Sprite>("Images/Inventory/Chest/sleeveless-jacket");
            }

            randomNumber = Random.Range(1, 3);
            if (randomNumber == 1)
            {
                //Use Asset Database
                Inventory[2].sprite = Resources.Load<Sprite>("Images/Inventory/Pants/shorts");
            }

            if (randomNumber == 2)
            {
                //Use Asset Database
                Inventory[2].sprite = Resources.Load<Sprite>("Images/Inventory/Pants/wooden-pegleg");
            }

            randomNumber = Random.Range(1, 3);
            if (randomNumber == 1)
            {
                //Use Asset Database
                Inventory[3].sprite = Resources.Load<Sprite>("Images/Inventory/Shields/police-badge");
            }

            if (randomNumber == 2)
            {
                //Use Asset Database
                Inventory[3].sprite = Resources.Load<Sprite>("Images/Inventory/Shields/templar-shield");
            }

            randomNumber = Random.Range(1, 4);
            if (randomNumber == 1)
            {
                //Use Asset Database
                Inventory[4].sprite = Resources.Load<Sprite>("Images/Inventory/Weapons/baseball-bat");
            }

            if (randomNumber == 2)
            {
                //Use Asset Database
                Inventory[4].sprite = Resources.Load<Sprite>("Images/Inventory/Weapons/crossbow");
            }

            if (randomNumber == 3)
            {
                //Use Asset Database
                Inventory[4].sprite = Resources.Load<Sprite>("Images/Inventory/Weapons/two-handed-sword");
            }
            Inventory[0].color = Color.red;
            Inventory[1].color = Color.blue;
            Inventory[2].color = Color.green;
            Inventory[3].color = Color.yellow;
            Inventory[4].color = Color.magenta;
        foreach (Image item in Equipment)
        {
            Items newItem = new Items();
            itemList.Add(newItem);
        }
        tint = Random.Range(1, 5);

        itemList[9].EnterItems(1, tint);
        randomNumber = Random.Range(1, 5);
        if (randomNumber == 1)
        {
            //Use Asset Database
            Equipment[0].sprite = Resources.Load<Sprite>("Images/Inventory/Helmets/brutal-helm");
        }

        if (randomNumber == 2)
        {
            //Use Asset Database
            Equipment[0].sprite = Resources.Load<Sprite>("Images/Inventory/Helmets/spartan-helmet");
        }

        if (randomNumber == 3)
        {
            //Use Asset Database
            Equipment[0].sprite = Resources.Load<Sprite>("Images/Inventory/Helmets/turban");
        }

        if (randomNumber == 4)
        {
            //Use Asset Database
            Equipment[0].sprite = Resources.Load<Sprite>("Images/Inventory/Helmets/viking-helmet");
        }
        if (itemList[9].tint == 0)
        {
            Equipment[0].color = Color.red;
        }
        if (itemList[9].tint == 1)
        {
            Equipment[0].color = Color.blue;
        }
        if (itemList[9].tint == 2)
        {
            Equipment[0].color = Color.green;
        }
        if (itemList[9].tint == 3)
        {
            Equipment[0].color = Color.yellow;
        }
        if (itemList[9].tint == 4)
        {
            Equipment[0].color = Color.magenta;
        }
        tint = Random.Range(1, 5);
        itemList[10].EnterItems(2, tint);
        randomNumber = Random.Range(1, 4);
        if (randomNumber == 1)
        {
            //Use Asset Database
            Equipment[1].sprite = Resources.Load<Sprite>("Images/Inventory/Chest/pirate-coat");
        }

        if (randomNumber == 2)
        {
            //Use Asset Database
            Equipment[1].sprite = Resources.Load<Sprite>("Images/Inventory/Chest/polo-shirt");
        }

        if (randomNumber == 3)
        {
            //Use Asset Database
            Equipment[1].sprite = Resources.Load<Sprite>("Images/Inventory/Chest/sleeveless-jacket");
        }
        if (itemList[10].tint == 0)
        {
            Equipment[1].color = Color.red;
        }
        if (itemList[10].tint == 1)
        {
            Equipment[1].color = Color.blue;
        }
        if (itemList[10].tint == 2)
        {
            Equipment[1].color = Color.green;
        }
        if (itemList[10].tint == 3)
        {
            Equipment[1].color = Color.yellow;
        }
        if (itemList[10].tint == 4)
        {
            Equipment[1].color = Color.magenta;
        }
        tint = Random.Range(1, 5);
        itemList[11].EnterItems(3, tint);
        randomNumber = Random.Range(1, 3);
        if (randomNumber == 1)
        {
            //Use Asset Database
            Equipment[2].sprite = Resources.Load<Sprite>("Images/Inventory/Pants/shorts");
        }

        if (randomNumber == 2)
        {
            //Use Asset Database
            Equipment[2].sprite = Resources.Load<Sprite>("Images/Inventory/Pants/wooden-pegleg");
        }
        if (itemList[11].tint == 0)
        {
            Equipment[2].color = Color.red;
        }
        if (itemList[11].tint == 1)
        {
            Equipment[2].color = Color.blue;
        }
        if (itemList[11].tint == 2)
        {
            Equipment[2].color = Color.green;
        }
        if (itemList[11].tint == 3)
        {
            Equipment[2].color = Color.yellow;
        }
        if (itemList[11].tint == 4)
        {
            Equipment[2].color = Color.magenta;
        }
        tint = Random.Range(1, 5);
        itemList[12].EnterItems(4, tint);
        randomNumber = Random.Range(1, 3);
        if (randomNumber == 1)
        {
            //Use Asset Database
            Equipment[3].sprite = Resources.Load<Sprite>("Images/Inventory/Shields/police-badge");
        }

        if (randomNumber == 2)
        {
            //Use Asset Database
            Equipment[3].sprite = Resources.Load<Sprite>("Images/Inventory/Shields/templar-shield");
        }
        if (itemList[12].tint == 0)
        {
            Equipment[3].color = Color.red;
        }
        if (itemList[12].tint == 1)
        {
            Equipment[3].color = Color.blue;
        }
        if (itemList[12].tint == 2)
        {
            Equipment[3].color = Color.green;
        }
        if (itemList[12].tint == 3)
        {
            Equipment[3].color = Color.yellow;
        }
        if (itemList[12].tint == 4)
        {
            Equipment[3].color = Color.magenta;
        }
        tint = Random.Range(1, 5);
        itemList[13].EnterItems(5, tint);
        randomNumber = Random.Range(1, 4);
        if (randomNumber == 1)
        {
            //Use Asset Database
            Equipment[4].sprite = Resources.Load<Sprite>("Images/Inventory/Weapons/baseball-bat");
        }

        if (randomNumber == 2)
        {
            //Use Asset Database
            Equipment[4].sprite = Resources.Load<Sprite>("Images/Inventory/Weapons/crossbow");
        }

        if (randomNumber == 3)
        {
            //Use Asset Database
            Equipment[4].sprite = Resources.Load<Sprite>("Images/Inventory/Weapons/two-handed-sword");
        }
        if (itemList[13].tint == 0)
        {
            Equipment[4].color = Color.red;
        }
        if (itemList[13].tint == 1)
        {
            Equipment[4].color = Color.blue;
        }
        if (itemList[13].tint == 2)
        {
            Equipment[4].color = Color.green;
        }
        if (itemList[13].tint == 3)
        {
            Equipment[4].color = Color.yellow;
        }
        if (itemList[13].tint == 4)
        {
            Equipment[4].color = Color.magenta;
        }
    }

    public void Compress()
    {
        for (int i = 0; i < Inventory.Length - 1; i++)
        {
            if (itemList[i].item == 0)
            {
                tempSprite = Inventory[i].sprite;
                tempColor = Inventory[i].color;

                Inventory[i].sprite = Inventory[i + 1].sprite;
                Inventory[i].color = Inventory[i + 1].color;

                Inventory[i + 1].sprite = tempSprite;
                Inventory[i + 1].color = tempColor;
                tint = itemList[i].tint;

                itemList[i].tint = itemList[i + 1].tint;
                itemList[i + 1].tint = tint;
                itemNumber = itemList[i].item;

                itemList[i].item = itemList[i + 1].item;
                itemList[i + 1].item = itemNumber;
            }
        }
    }
    #region Temporary Testing things
    //takes in, item, number, and tint, replacing first empty spot with that item, using the loop, once it finds an empty spot, call compress and finally break out.
    public void PlaceItem(Sprite item, int number, int tint)
    {
        for (int i = 0; i < Inventory.Length; i++)
        {
            if (itemList[i].item == 0)
            {
                Inventory[i].sprite = item;
                itemList[i].EnterItems(number, tint);

                if (itemList[i].tint == 1)
                {
                    Inventory[i].color = Color.blue;
                }
                if (itemList[i].tint == 2)
                {
                    Inventory[i].color = Color.green;
                }
                if (itemList[i].tint == 3)
                {
                    Inventory[i].color = Color.yellow;
                }
                if (itemList[i].tint == 4)
                {
                    Inventory[i].color = Color.magenta;
                }
                Compress();
                break;
            }
        }
    }

    public void Place1()
    {
        randomNumber = Random.Range(1, 5);
        if (randomNumber == 1)
        {
            //Use Asset Database
            tempSprite = Resources.Load<Sprite>("Images/Inventory/Helmets/brutal-helm");
        }

        if (randomNumber == 2)
        {
            //Use Asset Database
            tempSprite = Resources.Load<Sprite>("Images/Inventory/Helmets/spartan-helmet");
        }

        if (randomNumber == 3)
        {
            //Use Asset Database
            tempSprite = Resources.Load<Sprite>("Images/Inventory/Helmets/turban");
        }

        if (randomNumber == 4)
        {
            //Use Asset Database
            tempSprite = Resources.Load<Sprite>("Images/Inventory/Helmets/viking-helmet");
        }
        itemNumber = Random.Range(1, 5);
        tint = Random.Range(1, 5);
        PlaceItem(tempSprite, itemNumber, tint);
    }
    public void Place2()
    {
        randomNumber = Random.Range(1, 4);
        if (randomNumber == 1)
        {
            //Use Asset Database
            tempSprite = Resources.Load<Sprite>("Images/Inventory/Chest/pirate-coat");
        }

        if (randomNumber == 2)
        {
            //Use Asset Database
            tempSprite = Resources.Load<Sprite>("Images/Inventory/Chest/polo-shirt");
        }

        if (randomNumber == 3)
        {
            //Use Asset Database
            tempSprite = Resources.Load<Sprite>("Images/Inventory/Chest/sleeveless-jacket");
        }
        itemNumber = Random.Range(1, 5);
        tint = Random.Range(1, 5);
        PlaceItem(tempSprite, itemNumber, tint);
    }
    public void Place3()
    {
        randomNumber = Random.Range(1, 3);
        if (randomNumber == 1)
        {
            //Use Asset Database
            tempSprite = Resources.Load<Sprite>("Images/Inventory/Pants/shorts");
        }

        if (randomNumber == 2)
        {
            //Use Asset Database
            tempSprite = Resources.Load<Sprite>("Images/Inventory/Pants/wooden-pegleg");
        }
        itemNumber = Random.Range(1, 5);
        tint = Random.Range(1, 5);
        PlaceItem(tempSprite, itemNumber, tint);
    }
    public void Place4()

    {
        randomNumber = Random.Range(1, 3);
        if (randomNumber == 1)
        {
            //Use Asset Database
            tempSprite = Resources.Load<Sprite>("Images/Inventory/Shields/police-badge");
        }

        if (randomNumber == 2)
        {
            //Use Asset Database
            tempSprite = Resources.Load<Sprite>("Images/Inventory/Shields/templar-shield");
        }
        itemNumber = Random.Range(1, 5);
        tint = Random.Range(1, 5);
        PlaceItem(tempSprite, itemNumber, tint);
    }
    public void Place5()
    {
        randomNumber = Random.Range(1, 4);
        if (randomNumber == 1)
        {
            //Use Asset Database
            tempSprite = Resources.Load<Sprite>("Images/Inventory/Weapons/baseball-bat");
        }

        if (randomNumber == 2)
        {
            //Use Asset Database
            tempSprite = Resources.Load<Sprite>("Images/Inventory/Weapons/crossbow");
        }

        if (randomNumber == 3)
        {
            //Use Asset Database
            tempSprite = Resources.Load<Sprite>("Images/Inventory/Weapons/two-handed-sword");
        }
        itemNumber = Random.Range(1, 5);
        tint = Random.Range(1, 5);
        PlaceItem(tempSprite, itemNumber, tint);
    }
    #endregion
}
