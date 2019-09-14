using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visualizer : MonoBehaviour
{
    [SerializeField] int width = 20;
    [SerializeField] int height = 10;
    [SerializeField] GameObject floorTile;
    //[SerializeField] GameObject wallTile;
    [SerializeField] Color floorColor;
    [SerializeField] Color wallColor;

    public int[] mapData;

    private GameObject[] tileData;

    private void Start()
    {
        mapData = new int[width * height];
        tileData = new GameObject[mapData.Length];

        for (int i = 0; i < mapData.Length; i++)
        {
            mapData[i] = i % 2;
            tileData[i] = Instantiate(floorTile);
            if (mapData[i] == 0)
            {
                tileData[i].GetComponent<SpriteRenderer>().color = wallColor;
            }
            Vector3 newPos = tileData[i].transform.position;
            newPos.y = (height/2) - (i / width - .5f);
            newPos.x = (width / 2) - (i % width);
            tileData[i].transform.position = newPos;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Map_Randomization random = new Map_Randomization();
            random.width = this.width;
            random.height = this.height;
            random.GenerateLevel();
            this.mapData = random.mapData;
            DisplayMapData();
        }
    }

    public void DisplayMapData()
    {
        for(int i = 0; i < mapData.Length; i++)
        {
            if (mapData[i] == 0)
            {
                tileData[i].GetComponent<SpriteRenderer>().color = wallColor;
            }
            else tileData[i].GetComponent<SpriteRenderer>().color = floorColor;

        }
    }
}
