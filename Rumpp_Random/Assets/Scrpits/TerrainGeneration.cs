using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGeneration : MonoBehaviour
{
	// Start is called before the first frame update
	int resolution = 129;
	public TerrainData tData;
	float[,] heightArray;
	public Vector3 worldSize;
	// creates the terrain and height map 
	void Awake()
    {
		tData = gameObject.GetComponent<TerrainCollider>().terrainData;
		worldSize = new Vector3(200, 50, 200);
		tData.size = worldSize;
		tData.heightmapResolution = resolution;
		heightArray = new float[resolution, resolution];

		PerlinGen();

		tData.SetHeights(0,0,heightArray);
	}

    // Update is called once per frame
    void Update()
    {
        
    }

	//generates the terrain using perlin noise
	void PerlinGen()
	{
		float x = 0;
		float y = 0;
		for (int i = 0; i < resolution; i++)
		{
			for (int j = 0; j < resolution; j++)
			{
				heightArray[i, j] = Mathf.PerlinNoise(x, y) * .25f;
				y += .05f;
			}
			x += .05f;
			y = 0;
		}
	}

	//returns the height array
	public float[,] HeightArray
	{
		get { return heightArray; }
	}
}
