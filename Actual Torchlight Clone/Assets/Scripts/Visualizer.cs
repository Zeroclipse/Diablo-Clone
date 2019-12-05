using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Visualizer : MonoBehaviourPunCallbacks
{
    public bool firstTime = true;
    public int width = 20;
    public int height = 10;
    //[SerializeField] GameObject floorTile;
    //[SerializeField] GameObject wallTile;
    //[SerializeField] Color floorColor;
    //[SerializeField] Color wallColor;
    //public GameObject details;
    //public GameObject visualizer;

    public int[] mapData;

    private GameObject[] tileData;

    public void GenerateNewMap()
    {
        //details.SetActive(false);
        //visualizer.SetActive(true);
        //if (firstTime)
        //{
            mapData = new int[width * height];
            tileData = new GameObject[mapData.Length];

            for (int i = 0; i < mapData.Length; i++)
            {
                mapData[i] = i % 2;
                //tileData[i] = Instantiate(floorTile, visualizer.transform);
                if (mapData[i] == 0)
                {
                    //tileData[i].GetComponent<SpriteRenderer>().color = wallColor;
                }
                //Vector3 newPos = tileData[i].transform.position;
                //newPos.y = (height / 2) - (i / width - .5f);
                //newPos.x = (width / 2) - (i % width);
                //tileData[i].transform.position = newPos;
            }
            firstTime = false;
        //}
            Map_Randomization random = new Map_Randomization();
            random.width = this.width;
            random.height = this.height;
            random.GenerateLevel();
            this.mapData = random.mapData;
            DisplayMapData();
    }

    public void DisplayMapData()
    {
        for(int i = 0; i < mapData.Length; i++)
        {
            if (mapData[i] == 1)
            {
                //tileData[i].GetComponent<SpriteRenderer>().color = wallColor;
            }
            else if (mapData[i] == 2)
            {
                //tileData[i].GetComponent<SpriteRenderer>().color = floorColor;
            }
            else if (mapData[i] == 3)
            {
                //tileData[i].GetComponent<SpriteRenderer>().color = Color.green;
            }
            else if (mapData[i] == 4)
            {
                //tileData[i].GetComponent<SpriteRenderer>().color = Color.red;
            }

            else if (mapData[i] == 0)
            {
                //tileData[i].GetComponent<SpriteRenderer>().color = Color.yellow;
            }
        }
    }
}
