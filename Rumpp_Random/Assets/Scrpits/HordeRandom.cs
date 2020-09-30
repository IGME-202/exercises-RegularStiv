using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HordeRandom : MonoBehaviour
{
    //creates the public objects to be used in the inspector
    public GameObject hordeObject;
    public TerrainGeneration terrain;
    // Start is called before the first frame update
    void Start()
    {
        // creates the horde objects and sets their locations depending on the perlin generatiion also rotates randomly
        for (int i = 0; i < 75; i++)
        {
            float mean = 100;
            float stdDev = 25;
            GameObject temp = Instantiate(hordeObject);
            temp.transform.localScale = new Vector3(30, 30, 30);
            temp.transform.Rotate(new Vector3(0, Random.Range(0, 361), 0));
            float xLoc = Gaussian(mean / 2, stdDev / 2);
            float zLoc = Gaussian(mean, stdDev);
            // if it is inside the terrain it will set its position
            if (0 < xLoc && xLoc < terrain.worldSize.x && zLoc > 0 && zLoc < terrain.worldSize.z)
            {
                int indexX = (int)(xLoc * 129) / 200;
                int indexZ = (int)(zLoc * 129) / 200;
                temp.transform.position = new Vector3(xLoc, (terrain.HeightArray[indexZ, indexX] * terrain.worldSize.y), zLoc);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //uses standard devialtion to get positions  
    float Gaussian(float mean, float stdDev)
    {
        float val1 = Random.Range(0f, 1f);
        float val2 = Random.Range(0f, 1f);
        float gaussValue =
                 Mathf.Sqrt(-2.0f * Mathf.Log(val1)) *
                 Mathf.Sin(2.0f * Mathf.PI * val2);
        return mean + stdDev * gaussValue;
    }
}
