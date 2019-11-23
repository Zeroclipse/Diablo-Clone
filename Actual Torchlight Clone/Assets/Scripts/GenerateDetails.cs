using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateDetails : MonoBehaviour
{
    private Visualizer visualizer;
    private int[] mapData;
    public GameObject details;
    public GameObject visualizers;
    public GameObject[] rooms;
    private int width;
    private int height;
    private int randomNumber;
    private int[] location;
    private List<GameObject> objects;
    Vector3 position;
    private bool firstTime;
    public GameObject player;
    public GameObject boss;
    Quaternion rotation;
    private void Awake()
    {
        visualizer = GetComponent<Visualizer>();
        width = visualizer.width;
        height = visualizer.height;
        location = new int[2];
        objects = new List<GameObject>();
    }

    public void Details()
    {
        if (firstTime != true)
        {
            for(int i = 0; i < objects.Count; i++)
            {
                Destroy(objects[i]);
            }
            objects.Clear();
        }
        else if (firstTime == true)
        {
            firstTime = false;
        }
        if (visualizer.firstTime == false)
        {
            int heighMultiplier = 1;
            int widthMultiplier = 0;
            details.SetActive(true);
            visualizers.SetActive(false);
            mapData = visualizer.mapData;
            for (int i = 0; i < mapData.Length; i++)
            {
                if (i > width * heighMultiplier)
                {
                    heighMultiplier++;
                    widthMultiplier = 0;
                }
                location[0] = widthMultiplier * 49;
                location[1] = heighMultiplier * 49;
                position = new Vector3(location[1], 0, location[0] - 200);
                if (mapData[i] == 2 || mapData[i] == 3 || mapData[i] == 4)
                {
                    //Top
                    if (mapData[i - width] == 2 || mapData[i - width] == 3 || mapData[i - width] == 4)
                    {
                        //Top, Bottom
                        if (mapData[i + width] == 2 || mapData[i + width] == 3 || mapData[i + width] == 4)
                        {
                            //Top, Bottom, Forward
                            if (mapData[i - 1] == 2 || mapData[i - 1] == 3 || mapData[i - 1] == 4)
                            {
                                //Top, Bottom, Forward, Back
                                if (mapData[i + 1] == 2 || mapData[i + 1] == 3 || mapData[i + 1] == 4)
                                {
                                    rotation = Quaternion.Euler(0, 0, 0);
                                    randomNumber = Random.Range(1, 4);
                                    if (randomNumber == 1 || mapData[i] == 3 || mapData[i] == 4)
                                    {
                                        //Load from array at index 3 instantiating it at this spot, and maybe rotating it
                                        objects.Add(Instantiate(rooms[3], position, rotation, details.transform));
                                        position = new Vector3(location[1], 2, location[0] - 200);
                                        if (mapData[i] == 3)
                                        {
                                            objects.Add(Instantiate(player, position, Quaternion.identity));
                                        }
                                        else if (mapData[i] == 4)
                                        {
                                            objects.Add(Instantiate(boss, position, Quaternion.identity));
                                        }
                                    }
                                    else if (randomNumber == 2)
                                    {
                                        //Load from array at index 4 instantiating it at this spot, and maybe rotating it
                                        objects.Add(Instantiate(rooms[4], position, rotation, details.transform));
                                    }
                                    else if (randomNumber == 3)
                                    {
                                        //Load from array at index 5 instantiating it at this spot, and maybe rotating it
                                        objects.Add(Instantiate(rooms[5], position, rotation, details.transform));
                                    }
                                }
                                //Top, Bottom, Forward
                                else
                                {
                                    rotation = Quaternion.Euler(0, 180, 0);
                                    randomNumber = Random.Range(1, 4);
                                    if (randomNumber == 1 || mapData[i] == 3 || mapData[i] == 4)
                                    {
                                        //Load from array at index 6 instantiating it at this spot, and maybe rotating it
                                        objects.Add(Instantiate(rooms[6], position, rotation, details.transform));
                                        position = new Vector3(location[1], 2, location[0] - 200);
                                        if (mapData[i] == 3)
                                        {
                                            objects.Add(Instantiate(player, position, Quaternion.identity));
                                        }
                                        else if (mapData[i] == 4)
                                        {
                                            objects.Add(Instantiate(boss, position, Quaternion.identity));
                                        }
                                    }
                                    else if (randomNumber == 2)
                                    {
                                        //Load from array at index 7 instantiating it at this spot, and maybe rotating it
                                        Instantiate(rooms[7], position, rotation, details.transform);
                                    }
                                    else if (randomNumber == 3)
                                    {
                                        //Load from array at index 8 instantiating it at this spot, and maybe rotating it
                                        objects.Add(Instantiate(rooms[8], position, rotation, details.transform));
                                    }
                                }
                            }
                            //Top, Bottom
                            else
                            {
                                //Top, Bottom, back
                                if (mapData[i + 1] == 2 || mapData[i + 1] == 3 || mapData[i + 1] == 4)
                                {
                                    rotation = Quaternion.Euler(0, 0, 0);
                                    randomNumber = Random.Range(1, 4);
                                    if (randomNumber == 1 || mapData[i] == 3 || mapData[i] == 4)
                                    {
                                        //Load from array at index 6 instantiating it at this spot, and maybe rotating it
                                        objects.Add(Instantiate(rooms[6], position, rotation, details.transform));
                                        position = new Vector3(location[1], 2, location[0] - 200);
                                        if (mapData[i] == 3)
                                        {
                                            objects.Add(Instantiate(player, position, Quaternion.identity));
                                        }
                                        else if (mapData[i] == 4)
                                        {
                                            objects.Add(Instantiate(boss, position, Quaternion.identity));
                                        }
                                    }
                                    else if (randomNumber == 2)
                                    {
                                        //Load from array at index 7 instantiating it at this spot, and maybe rotating it
                                        Instantiate(rooms[7], position, rotation, details.transform);
                                    }
                                    else if (randomNumber == 3)
                                    {
                                        //Load from array at index 8 instantiating it at this spot, and maybe rotating it
                                        objects.Add(Instantiate(rooms[8], position, rotation, details.transform));
                                    }
                                }
                                //Top, Bottom
                                else
                                {
                                    randomNumber = Random.Range(1, 3);
                                    rotation = Quaternion.Euler(0, 0, 0);
                                    if (randomNumber == 1 || mapData[i] == 3 || mapData[i] == 4)
                                    {
                                        //Load from array at index 12 instantiating it at this spot, and maybe rotating it
                                        objects.Add(Instantiate(rooms[12], position, rotation, details.transform));
                                        position = new Vector3(location[1], 2, location[0] - 200);
                                        if (mapData[i] == 3)
                                        {
                                            objects.Add(Instantiate(player, position, Quaternion.identity));
                                        }
                                        else if (mapData[i] == 4)
                                        {
                                            objects.Add(Instantiate(boss, position, Quaternion.identity));
                                        }
                                    }
                                    else if (randomNumber == 2)
                                    {
                                        //Load from array at index 10 instantiating it at this spot, and maybe rotating it
                                        objects.Add(Instantiate(rooms[10], position, rotation, details.transform));
                                    }
                                }
                            }
                        }
                        //Top
                        else
                        {
                            //Top, Front
                            if (mapData[i - 1] == 2 || mapData[i - 1] == 3 || mapData[i - 1] == 4)
                            {
                                //Top, Front, Back
                                if (mapData[i + 1] == 2 || mapData[i + 1] == 3 || mapData[i + 1] == 4)
                                {
                                    rotation = Quaternion.Euler(0, 270, 0);
                                    randomNumber = Random.Range(1, 4);
                                    if (randomNumber == 1 || mapData[i] == 3 || mapData[i] == 4)
                                    {
                                        //Load from array at index 6 instantiating it at this spot, and maybe rotating it
                                        objects.Add(Instantiate(rooms[6], position, rotation, details.transform));
                                        position = new Vector3(location[1], 2, location[0] - 200);
                                        if (mapData[i] == 3)
                                        {
                                            objects.Add(Instantiate(player, position, Quaternion.identity));
                                        }
                                        else if (mapData[i] == 4)
                                        {
                                            objects.Add(Instantiate(boss, position, Quaternion.identity));
                                        }
                                    }
                                    else if (randomNumber == 2)
                                    {
                                        //Load from array at index 7 instantiating it at this spot, and maybe rotating it
                                        Instantiate(rooms[7], position, rotation, details.transform);
                                    }
                                    else if (randomNumber == 3)
                                    {
                                        //Load from array at index 8 instantiating it at this spot, and maybe rotating it
                                        objects.Add(Instantiate(rooms[8], position, rotation, details.transform));
                                    }
                                }
                                //Top, Front
                                else
                                {
                                    rotation = Quaternion.Euler(0, 180, 0);
                                    randomNumber = Random.Range(1, 3);
                                    if (randomNumber == 1 || mapData[i] == 3 || mapData[i] == 4)
                                    {
                                        //Load from array at index 9 instantiating it at this spot, and maybe rotating it
                                        objects.Add(Instantiate(rooms[9], position, rotation, details.transform));
                                        position = new Vector3(location[1], 2, location[0] - 200);
                                        if (mapData[i] == 3)
                                        {
                                            objects.Add(Instantiate(player, position, Quaternion.identity));
                                        }
                                        else if (mapData[i] == 4)
                                        {
                                            objects.Add(Instantiate(boss, position, Quaternion.identity));
                                        }
                                    }
                                    else if (randomNumber == 2)
                                    {
                                        //Load from array at index 11 instantiating it at this spot, and maybe rotating it
                                        objects.Add(Instantiate(rooms[11], position, rotation, details.transform));
                                    }
                                }
                            }

                            else //Top
                            {
                                //Top, Back
                                if (mapData[i + 1] == 2 || mapData[i + 1] == 3 || mapData[i + 1] == 4)
                                {
                                    rotation = Quaternion.Euler(0, 270, 0);
                                    randomNumber = Random.Range(1, 3);
                                    if (randomNumber == 1 || mapData[i] == 3 || mapData[i] == 4)
                                    {
                                        //Load from array at index 9 instantiating it at this spot, and maybe rotating it
                                        objects.Add(Instantiate(rooms[9], position, rotation, details.transform));
                                        position = new Vector3(location[1], 2, location[0] - 200);
                                        if (mapData[i] == 3)
                                        {
                                            objects.Add(Instantiate(player, position, Quaternion.identity));
                                        }
                                        else if (mapData[i] == 4)
                                        {
                                            objects.Add(Instantiate(boss, position, Quaternion.identity));
                                        }
                                    }
                                    else if (randomNumber == 2)
                                    {
                                        //Load from array at index 11 instantiating it at this spot, and maybe rotating it
                                        objects.Add(Instantiate(rooms[11], position, rotation, details.transform));
                                    }
                                }
                                //Top
                                else
                                {
                                    rotation = Quaternion.Euler(0, 270, 0);
                                    randomNumber = Random.Range(1, 4);
                                    if (randomNumber == 1 || mapData[i] == 3 || mapData[i] == 4)
                                    {
                                        //Load from array at index 0 instantiating it at this spot, and maybe rotating it
                                        objects.Add(Instantiate(rooms[0], position, rotation, details.transform));
                                        position = new Vector3(location[1], 2, location[0] - 200);
                                        if (mapData[i] == 3)
                                        {
                                            objects.Add(Instantiate(player, position, Quaternion.identity));
                                        }
                                        else if (mapData[i] == 4)
                                        {
                                            objects.Add(Instantiate(boss, position, Quaternion.identity));
                                        }
                                    }
                                    else if (randomNumber == 2)
                                    {
                                        //Load from array at index 1 instantiating it at this spot, and maybe rotating it
                                        objects.Add(Instantiate(rooms[1], position, rotation, details.transform));
                                    }
                                    else if (randomNumber == 3)
                                    {
                                        //Load from array at index 2 instantiating it at this spot, and maybe rotating it
                                        objects.Add(Instantiate(rooms[2], position, rotation, details.transform));
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        //Bottom
                        if (mapData[i + width] == 2 || mapData[i + width] == 3 || mapData[i + width] == 4)
                        {
                            //Bottom, Forward
                            if (mapData[i - 1] == 2 || mapData[i - 1] == 3 || mapData[i - 1] == 4)
                            {
                                //Bottom, Forward, Back
                                if (mapData[i + 1] == 2 || mapData[i + 1] == 3 || mapData[i + 1] == 4)
                                {
                                    rotation = Quaternion.Euler(0, 90, 0);
                                    randomNumber = Random.Range(1, 4);
                                    if (randomNumber == 1 || mapData[i] == 3 || mapData[i] == 4)
                                    {
                                        //Load from array at index 6 instantiating it at this spot, and maybe rotating it
                                        objects.Add(Instantiate(rooms[6], position, rotation, details.transform));
                                        position = new Vector3(location[1], 2, location[0] - 200);
                                        if (mapData[i] == 3)
                                        {
                                            objects.Add(Instantiate(player, position, Quaternion.identity));
                                        }
                                        else if (mapData[i] == 4)
                                        {
                                            objects.Add(Instantiate(boss, position, Quaternion.identity));
                                        }
                                    }
                                    else if (randomNumber == 2)
                                    {
                                        //Load from array at index 7 instantiating it at this spot, and maybe rotating it
                                        Instantiate(rooms[7], position, rotation, details.transform);
                                    }
                                    else if (randomNumber == 3)
                                    {
                                        //Load from array at index 8 instantiating it at this spot, and maybe rotating it
                                        objects.Add(Instantiate(rooms[8], position, rotation, details.transform));
                                    }
                                }
                                //Bottom, Forward
                                else
                                {
                                    rotation = Quaternion.Euler(0, 90, 0);
                                    randomNumber = Random.Range(1, 3);
                                    if (randomNumber == 1 || mapData[i] == 3 || mapData[i] == 4)
                                    {
                                        //Load from array at index 9 instantiating it at this spot, and maybe rotating it
                                        objects.Add(Instantiate(rooms[9], position, rotation, details.transform));
                                        position = new Vector3(location[1], 2, location[0] - 200);
                                        if (mapData[i] == 3)
                                        {
                                            objects.Add(Instantiate(player, position, Quaternion.identity));
                                        }
                                        else if (mapData[i] == 4)
                                        {
                                            objects.Add(Instantiate(boss, position, Quaternion.identity));
                                        }
                                    }
                                    else if (randomNumber == 2)
                                    {
                                        //Load from array at index 11 instantiating it at this spot, and maybe rotating it
                                        objects.Add(Instantiate(rooms[11], position, rotation, details.transform));
                                    }
                                }
                            }
                            //Bottom
                            else
                            {
                                //Bottom, back
                                if (mapData[i + 1] == 2 || mapData[i + 1] == 3 || mapData[i + 1] == 4)
                                {
                                    rotation = Quaternion.Euler(0, 0, 0);
                                    randomNumber = Random.Range(1, 3);
                                    if (randomNumber == 1 || mapData[i] == 3 || mapData[i] == 4)
                                    {
                                        //Load from array at index 9 instantiating it at this spot, and maybe rotating it
                                        objects.Add(Instantiate(rooms[9], position, rotation, details.transform));
                                        position = new Vector3(location[1], 2, location[0] - 200);
                                        if (mapData[i] == 3)
                                        {
                                            objects.Add(Instantiate(player, position, Quaternion.identity));
                                        }
                                        else if (mapData[i] == 4)
                                        {
                                            objects.Add(Instantiate(boss, position, Quaternion.identity));
                                        }
                                    }
                                    else if (randomNumber == 2)
                                    {
                                        //Load from array at index 11 instantiating it at this spot, and maybe rotating it
                                        objects.Add(Instantiate(rooms[11], position, rotation, details.transform));
                                    }
                                }
                                //Bottom
                                else
                                {
                                    rotation = Quaternion.Euler(0, 90, 0);
                                    randomNumber = Random.Range(1, 4);
                                    if (randomNumber == 1 || mapData[i] == 3 || mapData[i] == 4)
                                    {
                                        //Load from array at index 0 instantiating it at this spot, and maybe rotating it
                                        objects.Add(Instantiate(rooms[0], position, rotation, details.transform));
                                        position = new Vector3(location[1], 2, location[0] - 200);
                                        if (mapData[i] == 3)
                                        {
                                            objects.Add(Instantiate(player, position, Quaternion.identity));
                                        }
                                        else if (mapData[i] == 4)
                                        {
                                            objects.Add(Instantiate(boss, position, Quaternion.identity));
                                        }
                                    }
                                    else if (randomNumber == 2)
                                    {
                                        //Load from array at index 1 instantiating it at this spot, and maybe rotating it
                                        objects.Add(Instantiate(rooms[1], position, rotation, details.transform));
                                    }
                                    else if (randomNumber == 3)
                                    {
                                        //Load from array at index 2 instantiating it at this spot, and maybe rotating it
                                        objects.Add(Instantiate(rooms[2], position, rotation, details.transform));
                                    }
                                }
                            }
                        }
                        //None
                        else
                        {
                            //Front
                            if (mapData[i - 1] == 2 || mapData[i - 1] == 3 || mapData[i - 1] == 4)
                            {
                                //Front, Back
                                if (mapData[i + 1] == 2 || mapData[i + 1] == 3 || mapData[i + 1] == 4)
                                {
                                    randomNumber = Random.Range(1, 3);
                                    rotation = Quaternion.Euler(0, 90, 0);
                                    if (randomNumber == 1 || mapData[i] == 3 || mapData[i] == 4)
                                    {
                                        //Load from array at index 12 instantiating it at this spot, and maybe rotating it
                                        objects.Add(Instantiate(rooms[12], position, rotation, details.transform));
                                        position = new Vector3(location[1], 2, location[0] - 200);
                                        if (mapData[i] == 3)
                                        {
                                            objects.Add(Instantiate(player, position, Quaternion.identity));
                                        }
                                        else if (mapData[i] == 4)
                                        {
                                            objects.Add(Instantiate(boss, position, Quaternion.identity));
                                        }
                                    }
                                    else if (randomNumber == 2)
                                    {
                                        //Load from array at index 10 instantiating it at this spot, and maybe rotating it
                                        objects.Add(Instantiate(rooms[10], position, rotation, details.transform));
                                    }
                                }
                                //Front
                                else
                                {
                                    rotation = Quaternion.Euler(0, 180, 0);
                                    randomNumber = Random.Range(1, 4);
                                    if (randomNumber == 1 || mapData[i] == 3 || mapData[i] == 4)
                                    {
                                        //Load from array at index 0 instantiating it at this spot, and maybe rotating it
                                        objects.Add(Instantiate(rooms[0], position, rotation, details.transform));
                                        position = new Vector3(location[1], 2, location[0] - 200);
                                        if (mapData[i] == 3)
                                        {
                                            objects.Add(Instantiate(player, position, Quaternion.identity));
                                        }
                                        else if (mapData[i] == 4)
                                        {
                                            objects.Add(Instantiate(boss, position, Quaternion.identity));
                                        }
                                    }
                                    else if (randomNumber == 2)
                                    {
                                        //Load from array at index 1 instantiating it at this spot, and maybe rotating it
                                        objects.Add(Instantiate(rooms[1], position, rotation, details.transform));
                                    }
                                    else if (randomNumber == 3)
                                    {
                                        //Load from array at index 2 instantiating it at this spot, and maybe rotating it
                                        objects.Add(Instantiate(rooms[2], position, rotation, details.transform));
                                    }
                                }
                            }

                            else //None
                            {
                                //Back
                                if (mapData[i + 1] == 2 || mapData[i + 1] == 3 || mapData[i + 1] == 4)
                                {
                                    rotation = Quaternion.Euler(0, 0, 0);
                                    randomNumber = Random.Range(1, 4);
                                    if (randomNumber == 1 || mapData[i] == 3 || mapData[i] == 4)
                                    {
                                        //Load from array at index 0 instantiating it at this spot, and maybe rotating it
                                        objects.Add(Instantiate(rooms[0], position, rotation, details.transform));
                                        position = new Vector3(location[1], 2, location[0] - 200);
                                        if (mapData[i] == 3)
                                        {
                                            objects.Add(Instantiate(player, position, Quaternion.identity));
                                        }
                                        else if (mapData[i] == 4)
                                        {
                                            objects.Add(Instantiate(boss, position, Quaternion.identity));
                                        }
                                    }
                                    else if (randomNumber == 2)
                                    {
                                        //Load from array at index 1 instantiating it at this spot, and maybe rotating it
                                        objects.Add(Instantiate(rooms[1], position, rotation, details.transform));
                                    }
                                    else if (randomNumber == 3)
                                    {
                                        //Load from array at index 2 instantiating it at this spot, and maybe rotating it
                                        objects.Add(Instantiate(rooms[2], position, rotation, details.transform));
                                    }
                                }
                                //None, Final
                                else
                                {

                                }
                            }
                        }
                    }
                }
                widthMultiplier++;
            }
        }
    }
}
