using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Map_Randomization
{
    public int width;
    public int height;
    public int[] mapData;
    public int firstRoom = 98;

    public void GenerateLevel()
    {
        mapData = new int[width * height];
        int runtimes = 100;
        int bossLocation = 0;
        int endlocation = 0;
        int runs = 0;
        while (endlocation < 5)
        {
            runs++;
            if (runs == 10000)
            {
                break;
            }
            endlocation = 0;
            bool startSetupFinished = false;
            for (int j = 0; j <= runtimes; j++)
            {
                if (startSetupFinished != true)
                {
                    int heightMultiplier = 1;
                    for (int i = 0; i < mapData.Length; i++)
                    {
                        if (i == firstRoom)
                        {
                            mapData[i] = 3;
                            int guess = UnityEngine.Random.Range(1, 8);
                            if (guess == 1)
                            {
                                mapData[i - width] = 2;
                                mapData[i - 1] = 1;
                                mapData[i + width] = 1;
                            }

                            else if (guess == 2)
                            {
                                mapData[i - width] = 1;
                                mapData[i - 1] = 2;
                                mapData[i + width] = 1;
                            }

                            else if (guess == 3)
                            {
                                mapData[i - width] = 1;
                                mapData[i - 1] = 1;
                                mapData[i + width] = 2;
                            }

                            else if (guess == 4)
                            {
                                mapData[i - width] = 2;
                                mapData[i - 1] = 2;
                                mapData[i + width] = 1;
                            }

                            else if (guess == 5)
                            {
                                mapData[i - width] = 1;
                                mapData[i - 1] = 2;
                                mapData[i + width] = 2;
                            }

                            else if (guess == 6)
                            {
                                mapData[i - width] = 2;
                                mapData[i - 1] = 1;
                                mapData[i + width] = 2;
                            }

                            else if (guess == 7)
                            {
                                mapData[i - width] = 2;
                                mapData[i - 1] = 2;
                                mapData[i + width] = 2;
                            }
                        }
                        else if (i >= 0 && i < width || i >= width * height - width && i <= width * height)
                        {
                            mapData[i] = 1;
                        }
                        else if (i == width * heightMultiplier || i == width * heightMultiplier - 1)
                        {
                            mapData[i] = 1;
                        }

                        if (i > width * heightMultiplier)
                        {
                            heightMultiplier++;
                        }
                    }
                    for (int i = 0; i < mapData.Length; i++)
                    {
                        if (mapData[i] != 1 && mapData[i] != 2 && mapData[i] != 3)
                        {
                            mapData[i] = 0;
                            //Debug.Log(mapData[i]);
                        }
                        //mapData[i] = UnityEngine.Random.Range(1, 101) % 2;
                    }
                    startSetupFinished = true;
                }
                if (startSetupFinished == true)
                {
                    // Debug.Log("Start Setup is finished");
                    for (int i = 0; i < mapData.Length; i++)
                    {
                        if (mapData[i] == 2)
                        {
                            //bossLocation = i;
                            int random;
                            //int random1 = 3;
                            //int random2 = 3;
                            //int random3 = 3;
                            //int random4 = 3;
                            //Debug.Log(mapData[i]);
                            if (mapData[i - width] == 0)
                            {
                                // random1 = 1;
                                random = UnityEngine.Random.Range(1, 4);;
                                if (random == 2 || random == 3)
                                {
                                    mapData[i - width] = 2;
                                    endlocation++;
                                }
                                else
                                {
                                    mapData[i - width] = 1;
                                }
                            }
                            else
                            {
                                //random1 = 0;
                            }
                            if (mapData[i + width] == 0)
                            {
                                //random2 = 1;
                                random = UnityEngine.Random.Range(1, 4); ;
                                if (random == 2 || random == 3)
                                {
                                    mapData[i + width] = 2;
                                    endlocation++;
                                }
                                else
                                {
                                    mapData[i + width] = 1;
                                }
                            }
                            else
                            {
                                //random2 = 0;
                            }
                            if (mapData[i + 1] == 0)
                            {
                                //random3 = 1;
                                random = UnityEngine.Random.Range(1, 4); ;
                                if (random == 2 || random == 3)
                                {
                                    mapData[i + 1] = 2;
                                    endlocation++;
                                }
                                else
                                {
                                    mapData[i + 1] = 1;
                                }
                            }
                            else
                            {
                                //random3 = 0;
                            }
                            if (mapData[i - 1] == 0)
                            {
                                //random4 = 1;
                                random = UnityEngine.Random.Range(1, 4); ;
                                if (random == 2 || random == 3)
                                {
                                    mapData[i - 1] = 2;
                                    endlocation++;
                                }
                                else
                                {
                                    mapData[i - 1] = 1;
                                }
                            }
                            else
                            {
                                //random4 = 0;
                            }
                            #region randomThings to fix
                            //if (random1 == 1 && random2 == 1 && random3 == 1 && random4 == 1)
                            //{
                            //    int random5 = UnityEngine.Random.Range(1, 15);
                            //    if (random5 == 1)
                            //    {
                            //        mapData[i - width] = 2;
                            //        mapData[i + width] = 2;
                            //        mapData[i + 1] = 2;
                            //        mapData[i - 1] = 2;
                            //    }
                            //    if (random5 == 2)
                            //    {
                            //        mapData[i - width] = 1;
                            //        mapData[i + width] = 2;
                            //        mapData[i + 1] = 2;
                            //        mapData[i - 1] = 2;
                            //    }
                            //    if (random5 == 3)
                            //    {
                            //        mapData[i - width] = 2;
                            //        mapData[i + width] = 1;
                            //        mapData[i + 1] = 2;
                            //        mapData[i - 1] = 2;
                            //    }
                            //    if (random5 == 4)
                            //    {
                            //        mapData[i - width] = 2;
                            //        mapData[i + width] = 2;
                            //        mapData[i + 1] = 1;
                            //        mapData[i - 1] = 2;
                            //    }
                            //    if (random5 == 5)
                            //    {
                            //        mapData[i - width] = 2;
                            //        mapData[i + width] = 2;
                            //        mapData[i + 1] = 2;
                            //        mapData[i - 1] = 1;
                            //    }
                            //    if (random5 == 6)
                            //    {
                            //        mapData[i - width] = 1;
                            //        mapData[i + width] = 1;
                            //        mapData[i + 1] = 2;
                            //        mapData[i - 1] = 2;
                            //    }
                            //    if (random5 == 7)
                            //    {
                            //        mapData[i - width] = 2;
                            //        mapData[i + width] = 2;
                            //        mapData[i + 1] = 1;
                            //        mapData[i - 1] = 1;
                            //    }
                            //    if (random5 == 8)
                            //    {
                            //        mapData[i - width] = 2;
                            //        mapData[i + width] = 1;
                            //        mapData[i + 1] = 1;
                            //        mapData[i - 1] = 2;
                            //    }
                            //    if (random5 == 9)
                            //    {
                            //        mapData[i - width] = 1;
                            //        mapData[i + width] = 2;
                            //        mapData[i + 1] = 1;
                            //        mapData[i - 1] = 2;
                            //    }
                            //    if (random5 == 10)
                            //    {
                            //        mapData[i - width] = 2;
                            //        mapData[i + width] = 1;
                            //        mapData[i + 1] = 2;
                            //        mapData[i - 1] = 1;
                            //    }
                            //    if (random5 == 11)
                            //    {
                            //        mapData[i - width] = 2;
                            //        mapData[i + width] = 1;
                            //        mapData[i + 1] = 1;
                            //        mapData[i - 1] = 1;
                            //    }
                            //    if (random5 == 12)
                            //    {
                            //        mapData[i - width] = 1;
                            //        mapData[i + width] = 2;
                            //        mapData[i + 1] = 1;
                            //        mapData[i - 1] = 1;
                            //    }
                            //    if (random5 == 13)
                            //    {
                            //        mapData[i - width] = 1;
                            //        mapData[i + width] = 1;
                            //        mapData[i + 1] = 2;
                            //        mapData[i - 1] = 1;
                            //    }
                            //    if (random5 == 14)
                            //    {
                            //        mapData[i - width] = 1;
                            //        mapData[i + width] = 1;
                            //        mapData[i + 1] = 1;
                            //        mapData[i - 1] = 2;
                            //    }
                            //}
                            //if (random1 == 0 && random2 == 1 && random3 == 1 && random4 == 1)
                            //{
                            //    int random5 = UnityEngine.Random.Range(1, 7);
                            //    if (random5 == 1)
                            //    {
                            //        mapData[i - width] = 1;
                            //        mapData[i + width] = 2;
                            //        mapData[i + 1] = 2;
                            //        mapData[i - 1] = 2;
                            //    }
                            //    if (random5 == 2)
                            //    {
                            //        mapData[i - width] = 1;
                            //        mapData[i + width] = 1;
                            //        mapData[i + 1] = 2;
                            //        mapData[i - 1] = 2;
                            //    }
                            //    if (random5 == 3)
                            //    {
                            //        mapData[i - width] = 1;
                            //        mapData[i + width] = 2;
                            //        mapData[i + 1] = 1;
                            //        mapData[i - 1] = 2;
                            //    }
                            //    if (random5 == 4)
                            //    {
                            //        mapData[i - width] = 1;
                            //        mapData[i + width] = 2;
                            //        mapData[i + 1] = 1;
                            //        mapData[i - 1] = 1;
                            //    }
                            //    if (random5 == 5)
                            //    {
                            //        mapData[i - width] = 1;
                            //        mapData[i + width] = 1;
                            //        mapData[i + 1] = 2;
                            //        mapData[i - 1] = 1;
                            //    }
                            //    if (random5 == 6)
                            //    {
                            //        mapData[i - width] = 1;
                            //        mapData[i + width] = 1;
                            //        mapData[i + 1] = 1;
                            //        mapData[i - 1] = 2;
                            //    }
                            //}
                            //if (random1 == 1 && random2 == 0 && random3 == 1 && random4 == 1)
                            //{
                            //    int random5 = UnityEngine.Random.Range(1, 6);
                            //    if (random5 == 1)
                            //    {
                            //        mapData[i - width] = 2;
                            //        mapData[i + width] = 1;
                            //        mapData[i + 1] = 1;
                            //        mapData[i - 1] = 2;
                            //    }
                            //    if (random5 == 2)
                            //    {
                            //        mapData[i - width] = 2;
                            //        mapData[i + width] = 1;
                            //        mapData[i + 1] = 2;
                            //        mapData[i - 1] = 1;
                            //    }
                            //    if (random5 == 3)
                            //    {
                            //        mapData[i - width] = 2;
                            //        mapData[i + width] = 1;
                            //        mapData[i + 1] = 1;
                            //        mapData[i - 1] = 1;
                            //    }
                            //    if (random5 == 4)
                            //    {
                            //        mapData[i - width] = 1;
                            //        mapData[i + width] = 1;
                            //        mapData[i + 1] = 2;
                            //        mapData[i - 1] = 1;
                            //    }
                            //    if (random5 == 5)
                            //    {
                            //        mapData[i - width] = 1;
                            //        mapData[i + width] = 1;
                            //        mapData[i + 1] = 1;
                            //        mapData[i - 1] = 2;
                            //    }
                            //}
                            //if (random1 == 1 && random2 == 1 && random3 == 0 && random4 == 1)
                            //{
                            //    int random5 = UnityEngine.Random.Range(1, 8);

                            //    if (random5 == 1)
                            //    {
                            //        mapData[i - width] = 2;
                            //        mapData[i + width] = 2;
                            //        mapData[i + 1] = 1;
                            //        mapData[i - 1] = 2;
                            //    }
                            //    if (random5 == 2)
                            //    {
                            //        mapData[i - width] = 2;
                            //        mapData[i + width] = 2;
                            //        mapData[i + 1] = 1;
                            //        mapData[i - 1] = 1;
                            //    }
                            //    if (random5 == 3)
                            //    {
                            //        mapData[i - width] = 2;
                            //        mapData[i + width] = 1;
                            //        mapData[i + 1] = 1;
                            //        mapData[i - 1] = 2;
                            //    }
                            //    if (random5 == 4)
                            //    {
                            //        mapData[i - width] = 1;
                            //        mapData[i + width] = 2;
                            //        mapData[i + 1] = 1;
                            //        mapData[i - 1] = 2;
                            //    }
                            //    if (random5 == 5)
                            //    {
                            //        mapData[i - width] = 2;
                            //        mapData[i + width] = 1;
                            //        mapData[i + 1] = 1;
                            //        mapData[i - 1] = 1;
                            //    }
                            //    if (random5 == 6)
                            //    {
                            //        mapData[i - width] = 1;
                            //        mapData[i + width] = 2;
                            //        mapData[i + 1] = 1;
                            //        mapData[i - 1] = 1;
                            //    }
                            //    if (random5 == 7)
                            //    {
                            //        mapData[i - width] = 1;
                            //        mapData[i + width] = 1;
                            //        mapData[i + 1] = 1;
                            //        mapData[i - 1] = 2;
                            //    }
                            //}
                            //if (random1 == 1 && random2 == 1 && random3 == 1 && random4 == 0)
                            //{
                            //    int random5 = UnityEngine.Random.Range(1, 7);

                            //    if (random5 == 1)
                            //    {
                            //        mapData[i - width] = 2;
                            //        mapData[i + width] = 2;
                            //        mapData[i + 1] = 2;
                            //        mapData[i - 1] = 1;
                            //    }
                            //    if (random5 == 2)
                            //    {
                            //        mapData[i - width] = 2;
                            //        mapData[i + width] = 2;
                            //        mapData[i + 1] = 1;
                            //        mapData[i - 1] = 1;
                            //    }
                            //    if (random5 == 3)
                            //    {
                            //        mapData[i - width] = 2;
                            //        mapData[i + width] = 1;
                            //        mapData[i + 1] = 2;
                            //        mapData[i - 1] = 1;
                            //    }
                            //    if (random5 == 4)
                            //    {
                            //        mapData[i - width] = 2;
                            //        mapData[i + width] = 1;
                            //        mapData[i + 1] = 1;
                            //        mapData[i - 1] = 1;
                            //    }
                            //    if (random5 == 5)
                            //    {
                            //        mapData[i - width] = 1;
                            //        mapData[i + width] = 2;
                            //        mapData[i + 1] = 1;
                            //        mapData[i - 1] = 1;
                            //    }
                            //    if (random5 == 6)
                            //    {
                            //        mapData[i - width] = 1;
                            //        mapData[i + width] = 1;
                            //        mapData[i + 1] = 2;
                            //        mapData[i - 1] = 1;
                            //    }
                            //}
                            //if (random1 == 0 && random2 == 0 && random3 == 1 && random4 == 1)
                            //{
                            //    int random5 = UnityEngine.Random.Range(1, 4);
                            //    if (random5 == 1)
                            //    {
                            //        mapData[i - width] = 1;
                            //        mapData[i + width] = 1;
                            //        mapData[i + 1] = 2;
                            //        mapData[i - 1] = 2;
                            //    }
                            //    if (random5 == 2)
                            //    {
                            //        mapData[i - width] = 1;
                            //        mapData[i + width] = 1;
                            //        mapData[i + 1] = 2;
                            //        mapData[i - 1] = 1;
                            //    }
                            //    if (random5 == 3)
                            //    {
                            //        mapData[i - width] = 1;
                            //        mapData[i + width] = 1;
                            //        mapData[i + 1] = 1;
                            //        mapData[i - 1] = 2;
                            //    }
                            //}
                            //if (random1 == 1 && random2 == 0 && random3 == 0 && random4 == 1)
                            //{
                            //    int random5 = UnityEngine.Random.Range(1, 4);
                            //    if (random5 == 1)
                            //    {
                            //        mapData[i - width] = 2;
                            //        mapData[i + width] = 1;
                            //        mapData[i + 1] = 1;
                            //        mapData[i - 1] = 2;
                            //    }
                            //    if (random5 == 2)
                            //    {
                            //        mapData[i - width] = 2;
                            //        mapData[i + width] = 1;
                            //        mapData[i + 1] = 1;
                            //        mapData[i - 1] = 1;
                            //    }
                            //    if (random5 == 3)
                            //    {
                            //        mapData[i - width] = 1;
                            //        mapData[i + width] = 1;
                            //        mapData[i + 1] = 1;
                            //        mapData[i - 1] = 2;
                            //    }
                            //}
                            //if (random1 == 1 && random2 == 1 && random3 == 0 && random4 == 0)
                            //{
                            //    int random5 = UnityEngine.Random.Range(1, 4);
                            //    if (random5 == 1)
                            //    {
                            //        mapData[i - width] = 2;
                            //        mapData[i + width] = 2;
                            //        mapData[i + 1] = 1;
                            //        mapData[i - 1] = 1;
                            //    }
                            //    if (random5 == 2)
                            //    {
                            //        mapData[i - width] = 2;
                            //        mapData[i + width] = 1;
                            //        mapData[i + 1] = 1;
                            //        mapData[i - 1] = 1;
                            //    }
                            //    if (random5 == 3)
                            //    {
                            //        mapData[i - width] = 1;
                            //        mapData[i + width] = 2;
                            //        mapData[i + 1] = 1;
                            //        mapData[i - 1] = 1;
                            //    }
                            //}
                            //if (random1 == 0 && random2 == 1 && random3 == 0 && random4 == 1)
                            //{
                            //    int random5 = UnityEngine.Random.Range(1, 4);

                            //    if (random5 == 1)
                            //    {
                            //        mapData[i - width] = 1;
                            //        mapData[i + width] = 2;
                            //        mapData[i + 1] = 1;
                            //        mapData[i - 1] = 2;
                            //    }
                            //    if (random5 == 2)
                            //    {
                            //        mapData[i - width] = 1;
                            //        mapData[i + width] = 2;
                            //        mapData[i + 1] = 1;
                            //        mapData[i - 1] = 1;
                            //    }
                            //    if (random5 == 3)
                            //    {
                            //        mapData[i - width] = 1;
                            //        mapData[i + width] = 1;
                            //        mapData[i + 1] = 1;
                            //        mapData[i - 1] = 2;
                            //    }
                            //}
                            //if (random1 == 1 && random2 == 0 && random3 == 1 && random4 == 0)
                            //{
                            //    int random5 = UnityEngine.Random.Range(1, 4);
                            //    if (random5 == 1)
                            //    {
                            //        mapData[i - width] = 2;
                            //        mapData[i + width] = 1;
                            //        mapData[i + 1] = 2;
                            //        mapData[i - 1] = 1;
                            //    }
                            //    if (random5 == 2)
                            //    {
                            //        mapData[i - width] = 2;
                            //        mapData[i + width] = 1;
                            //        mapData[i + 1] = 1;
                            //        mapData[i - 1] = 1;
                            //    }
                            //    if (random5 == 3)
                            //    {
                            //        mapData[i - width] = 1;
                            //        mapData[i + width] = 1;
                            //        mapData[i + 1] = 2; 
                            //        mapData[i - 1] = 1;
                            //    }
                            //}
                            //if (random1 == 1 && random2 == 0 && random3 == 0 && random4 == 0)
                            //{
                            //    int random5 = UnityEngine.Random.Range(1, 2);
                            //    if (random5 == 1)
                            //    {
                            //        mapData[i - width] = 1;
                            //    }
                            //    if (random5 == 2)
                            //    {
                            //        mapData[i - width] = 2;
                            //    }
                            //}
                            //if (random1 == 0 && random2 == 1 && random3 == 0 && random4 == 0)
                            //{
                            //    int random5 = UnityEngine.Random.Range(1, 2);
                            //    if (random5 == 1)
                            //    {
                            //        mapData[i + width] = 1;
                            //    }
                            //    if (random5 == 2)
                            //    {
                            //        mapData[i + width] = 2;
                            //    }
                            //}
                            //if (random1 == 0 && random2 == 0 && random3 == 1 && random4 == 0)
                            //{
                            //    int random5 = UnityEngine.Random.Range(1, 2);
                            //    if (random5 == 1)
                            //    {
                            //        mapData[i + 1] = 1;
                            //    }
                            //    if (random5 == 2)
                            //    {
                            //        mapData[i + 1] = 2;
                            //    }
                            //}
                            //if (random1 == 0 && random2 == 0 && random3 == 0 && random4 == 1)
                            //{
                            //    int random5 = UnityEngine.Random.Range(1, 2);
                            //    if (random5 == 1)
                            //    {
                            //        mapData[i - 1] = 1;
                            //    }
                            //    if (random5 == 2)
                            //    {
                            //        mapData[i - 1] = 2;
                            //    }
                            //}
                            #endregion
                        }
                    }
                }
            }
            for (int i = 0; i < mapData.Length; i++)
            {
                if (mapData[i] == 2)
                {
                    bossLocation = i;
                    break;
                }
            }
                mapData[bossLocation] = 4;
        }
    }
}
