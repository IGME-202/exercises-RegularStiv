using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class TerrainGeneration : MonoBehaviour
{
    private TerrainData tData;
    private Vector3 worldSize;
    public int resolution = 129;
    float[,] heightMap;
    // Start is called before the first frame update
    void Start()
    {
        tData = gameObject.GetComponent<TerrainCollider>().terrainData;
        worldSize = new Vector3(250, 50, 250);
        tData.size = worldSize;
        tData.heightmapResolution = resolution;
        heightMap = new float[resolution, resolution];
        tData.SetHeights(0,0, CreateHeights());
    }

    // Update is called once per frame
    void Update()
    {

    }

    float[,] CreateHeights()
    {
        for (int i = 0; i < resolution; i++)
        {
            for (int j = 0; j < resolution; j++)
            {
                heightMap[i, j] = (float)i/resolution;
            }
        }
        return heightMap;
    }
}
