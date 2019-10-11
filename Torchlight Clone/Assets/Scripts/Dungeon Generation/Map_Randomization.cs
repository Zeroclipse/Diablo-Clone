using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Map_Randomization
{
    public int width;
    public int height;
    public int[] mapData;

    public void GenerateLevel()
    {
        mapData = new int[width * height];

        for (int i = 0; i < mapData.Length; i++)
        {
            mapData[i] = UnityEngine.Random.Range(1, 101) % 2;
        }
    }
}
