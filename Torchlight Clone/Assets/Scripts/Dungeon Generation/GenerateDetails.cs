using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateDetails : MonoBehaviour
{
    private Visualizer visualizer;
    private int[] mapData;
    public GameObject details;
    public GameObject visualizers;
    private void Awake()
    {
        visualizer = GetComponent<Visualizer>();
    }

    public void Details()
    {
        if (visualizer.firstTime == false)
        {
            details.SetActive(true);
            visualizers.SetActive(false);
            mapData = visualizer.mapData;
            for (int i = 0; i < mapData.Length; i++)
            {
                if (mapData[i] == 2 || mapData[i] == 3 || mapData[i] == 4)
                {

                }
            }
        }
    }
}
