using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherRandom : MonoBehaviour
{
    //ispector objects
    public GameObject randomObject;
    public TerrainGeneration terrain;
    // Start is called before the first frame update
    void Start()
    {
        //creates objects in the scene with completely random positions on the terrain
        for (int i = 0; i < 30; i++)
        {
            GameObject temp = Instantiate(randomObject);
            temp.transform.localScale = new Vector3(5, 5, 5);
            float xRand = Random.Range(0, 200);
            float zRand = Random.Range(0, 200);
            int indexX = (int)(xRand * 129) / 200;
            int indexZ = (int)(zRand * 129) / 200;
            temp.transform.position = new Vector3(xRand, (terrain.HeightArray[indexZ, indexX] * terrain.worldSize.y), zRand);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
