using System.Collections;
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

    private void Awake()
    {
        itemList = new List<Items>();
        //Temporary

        foreach (Image item in Inventory)
        {
            Items newItem = new Items();
            itemList.Add(newItem);
        }

        randomNumber = Random.Range(1, 5);
        //Finish
        if (randomNumber == 1)
        {
            //Use Asset Database
            Inventory[0].sprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Images/Helmets/brutal-helm.png", typeof(Sprite));
        }

        if (randomNumber == 2)
        {
            //Use Asset Database
            Inventory[0].sprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Images/Helmets/spartan-helmet.png", typeof(Sprite));
        }

        if (randomNumber == 3)
        {
            //Use Asset Database
            Inventory[0].sprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Images/Helmets/turban.png", typeof(Sprite));
        }

        if (randomNumber == 4)
        {
            //Use Asset Database
            Inventory[0].sprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Images/Helmets/viking-helmet.png", typeof(Sprite));
        }
            randomNumber = Random.Range(1, 4);
            if (randomNumber == 1)
            {
                //Use Asset Database
                Inventory[1].sprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Images/Chest/pirate-coat.png", typeof(Sprite));
            }

            if (randomNumber == 2)
            {
                //Use Asset Database
                Inventory[1].sprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Images/Chest/polo-shirt.png", typeof(Sprite));
            }

            if (randomNumber == 3)
            {
                //Use Asset Database
                Inventory[1].sprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Images/Chest/sleeveless-jacket.png", typeof(Sprite));
            }

            randomNumber = Random.Range(1, 3);
            if (randomNumber == 1)
            {
                //Use Asset Database
                Inventory[2].sprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Images/Pants/shorts.png", typeof(Sprite));
            }

            if (randomNumber == 2)
            {
                //Use Asset Database
                Inventory[2].sprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Images/Pants/wooden-pegleg.png", typeof(Sprite));
            }

            randomNumber = Random.Range(1, 3);
            if (randomNumber == 1)
            {
                //Use Asset Database
                Inventory[3].sprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Images/Shields/police-badge.png", typeof(Sprite));
            }

            if (randomNumber == 2)
            {
                //Use Asset Database
                Inventory[3].sprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Images/Shields/templar-shield.png", typeof(Sprite));
            }

            randomNumber = Random.Range(1, 4);
            if (randomNumber == 1)
            {
                //Use Asset Database
                Inventory[4].sprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Images/Weapons/baseball-bat.png", typeof(Sprite));
            }

            if (randomNumber == 2)
            {
                //Use Asset Database
                Inventory[4].sprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Images/Weapons/crossbow.png", typeof(Sprite));
            }

            if (randomNumber == 3)
            {
                //Use Asset Database
                Inventory[4].sprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Images/Weapons/two-handed-sword.png", typeof(Sprite));
            }
            Inventory[0].color = Color.red;
            Inventory[1].color = Color.blue;
            Inventory[2].color = Color.green;
            Inventory[3].color = Color.yellow;
            Inventory[4].color = Color.magenta;
        // }
        //}
        //for (int i = 0; i < Inventory.Length; i++)
        //{
        //    itemList[i].EnterItems(Random.Range(1, 6));
        //    if (itemList[i].item == 1) //Helmet
        //    {
        //        randomNumber = Random.Range(1, 5);
        //        //Finish
        //        if (randomNumber == 1)
        //        {
        //            //Use Asset Database
        //            Inventory[i].sprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Images/Helmets/brutal-helm.png", typeof(Sprite));
        //        }

        //        if (randomNumber == 2)
        //        {
        //            //Use Asset Database
        //            Inventory[i].sprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Images/Helmets/spartan-helmet.png", typeof(Sprite));
        //        }

        //        if (randomNumber == 3)
        //        {
        //            //Use Asset Database
        //            Inventory[i].sprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Images/Helmets/turban.png", typeof(Sprite));
        //        }

        //        if (randomNumber == 4)
        //        {
        //            //Use Asset Database
        //            Inventory[i].sprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Images/Helmets/viking-helmet.png", typeof(Sprite));
        //        }
        //    }

        //    else if (itemList[i].item == 2) //Chest
        //    {
        //        randomNumber = Random.Range(1, 4);
        //        if (randomNumber == 1)
        //        {
        //            //Use Asset Database
        //            Inventory[i].sprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Images/Chest/pirate-coat.png", typeof(Sprite));
        //        }

        //        if (randomNumber == 2)
        //        {
        //            //Use Asset Database
        //            Inventory[i].sprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Images/Chest/polo-shirt.png", typeof(Sprite));
        //        }

        //        if (randomNumber == 3)
        //        {
        //            //Use Asset Database
        //            Inventory[i].sprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Images/Chest/sleeveless-jacket.png", typeof(Sprite));
        //        }
        //    }

        //    else if (itemList[i].item == 3) //Pants
        //    {
        //        randomNumber = Random.Range(1, 3);
        //        if (randomNumber == 1)
        //        {
        //            //Use Asset Database
        //            Inventory[i].sprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Images/Pants/shorts.png", typeof(Sprite));
        //        }

        //        if (randomNumber == 2)
        //        {
        //            //Use Asset Database
        //            Inventory[i].sprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Images/Pants/wooden-pegleg.png", typeof(Sprite));
        //        }
        //    }

        //    else if (itemList[i].item == 4) //Shield
        //    {
        //        randomNumber = Random.Range(1, 3);
        //        if (randomNumber == 1)
        //        {
        //            //Use Asset Database
        //            Inventory[i].sprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Images/Shields/police-badge.png", typeof(Sprite));
        //        }

        //        if (randomNumber == 2)
        //        {
        //            //Use Asset Database
        //            Inventory[i].sprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Images/Shields/templar-shield.png", typeof(Sprite));
        //        }
        //    }

        //    else if (itemList[i].item == 5) //Sword
        //    {
        //        randomNumber = Random.Range(1, 4);
        //        if (randomNumber == 1)
        //        {
        //            //Use Asset Database
        //            Inventory[i].sprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Images/Weapons/baseball-bat.png", typeof(Sprite));
        //        }

        //        if (randomNumber == 2)
        //        {
        //            //Use Asset Database
        //            Inventory[i].sprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Images/Weapons/crossbow.png", typeof(Sprite));
        //        }

        //        if (randomNumber == 3)
        //        {
        //            //Use Asset Database
        //            Inventory[i].sprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Images/Weapons/two-handed-sword.png", typeof(Sprite));
        //        }
        //    }

        //    else
        //    {
        //    }
        //    if (itemList[i].tint == 0)
        //    {
        //        Inventory[i].color = Color.red;
        //    }
        //    if (itemList[i].tint == 1)
        //    {
        //        Inventory[i].color = Color.blue;
        //    }
        //    if (itemList[i].tint == 2)
        //    {
        //        Inventory[i].color = Color.green;
        //    }
        //    if (itemList[i].tint == 3)
        //    {
        //        Inventory[i].color = Color.yellow;
        //    }
        //    if (itemList[i].tint == 4)
        //    {
        //        Inventory[i].color = Color.magenta;
        //    }
        //}
        foreach (Image item in Equipment)
        {
            Items newItem = new Items();
            itemList.Add(newItem);
        }

        itemList[9].EnterItems(1);
        randomNumber = Random.Range(1, 5);
        if (randomNumber == 1)
        {
            //Use Asset Database
            Equipment[0].sprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Images/Helmets/brutal-helm.png", typeof(Sprite));
        }

        if (randomNumber == 2)
        {
            //Use Asset Database
            Equipment[0].sprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Images/Helmets/spartan-helmet.png", typeof(Sprite));
        }

        if (randomNumber == 3)
        {
            //Use Asset Database
            Equipment[0].sprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Images/Helmets/turban.png", typeof(Sprite));
        }

        if (randomNumber == 4)
        {
            //Use Asset Database
            Equipment[0].sprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Images/Helmets/viking-helmet.png", typeof(Sprite));
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
        itemList[10].EnterItems(2);
        randomNumber = Random.Range(1, 4);
        if (randomNumber == 1)
        {
            //Use Asset Database
            Equipment[1].sprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Images/Chest/pirate-coat.png", typeof(Sprite));
        }

        if (randomNumber == 2)
        {
            //Use Asset Database
            Equipment[1].sprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Images/Chest/polo-shirt.png", typeof(Sprite));
        }

        if (randomNumber == 3)
        {
            //Use Asset Database
            Equipment[1].sprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Images/Chest/sleeveless-jacket.png", typeof(Sprite));
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
        itemList[11].EnterItems(3);
        randomNumber = Random.Range(1, 3);
        if (randomNumber == 1)
        {
            //Use Asset Database
            Equipment[2].sprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Images/Pants/shorts.png", typeof(Sprite));
        }

        if (randomNumber == 2)
        {
            //Use Asset Database
            Equipment[2].sprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Images/Pants/wooden-pegleg.png", typeof(Sprite));
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
        itemList[12].EnterItems(4);
        randomNumber = Random.Range(1, 3);
        if (randomNumber == 1)
        {
            //Use Asset Database
            Equipment[3].sprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Images/Shields/police-badge.png", typeof(Sprite));
        }

        if (randomNumber == 2)
        {
            //Use Asset Database
            Equipment[3].sprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Images/Shields/templar-shield.png", typeof(Sprite));
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
        itemList[13].EnterItems(5);
        randomNumber = Random.Range(1, 4);
        if (randomNumber == 1)
        {
            //Use Asset Database
            Equipment[4].sprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Images/Weapons/baseball-bat.png", typeof(Sprite));
        }

        if (randomNumber == 2)
        {
            //Use Asset Database
            Equipment[4].sprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Images/Weapons/crossbow.png", typeof(Sprite));
        }

        if (randomNumber == 3)
        {
            //Use Asset Database
            Equipment[4].sprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Images/Weapons/two-handed-sword.png", typeof(Sprite));
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
                //if (itemList[0] && itemList[i - 1].item == 0 && itemList[i].item != 0)
                //{
                //    i -= 2;
                //}
            }
        }
        //int i = 0;
        //bool answer = false;
        //foreach (Image item in Inventory)
        //{
        //    if (itemList[i].item == 0 && itemList[1].item != 0 && itemList[i] != itemsList[1])
        //    {
        //        answer = true;
        //    }
        //    else if (itemList[i].item == 0 && itemList[2].item != 0)
        //    {
        //        Compress();
        //    }
        //    else if (itemList[i].item == 0 && itemList[3].item != 0)
        //    {
        //        Compress();
        //    }
        //    i++;
        //}
        //if (itemList[0].item == 0 && itemList[1].item != 0)
        //{
        //    Compress();
        //}
        //else if (itemList[1].item == 0 && itemList[2].item != 0)
        //{
        //    Compress();
        //}
        //else if (itemList[1].item == 0 && itemList[2].item != 0)
        //{
        //    Compress();
        //}
    }

    //takes in, item, number, and tint, replacing first empty spot with that item, using the loop, once it finds an empty spot, call compress and finally break out.
    public void PlaceItem()
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

    public void Place1()
    {

    }
    public void Place2()
    {

    }
    public void Place3()
    {

    }
    public void Place4()
    {

    }
    public void Place5()
    {

    }
}
