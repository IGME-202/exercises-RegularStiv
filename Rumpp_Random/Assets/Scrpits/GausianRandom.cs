using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GausianRandom : MonoBehaviour
{
    public GameObject gaussianObj;
   
    
    public TerrainGeneration terrain;
    
    Vector3 v3;
    // Start is called before the first frame update
    void Start()
    {
        //generates the gausian leaders in a line not completely straight looking the same way
        for (int i = 0; i < 10; i++)
        {
            float mean = 1;
            float stdDev = .2f;
            GameObject temp = Instantiate(gaussianObj);   
            int x = (int)terrain.worldSize.x - 75 - Random.Range(0, 50);
            int z = (int)terrain.worldSize.z - 100 - Random.Range(0, 10);
            //takes into account the resolution to the size of the terrain
            int indexX = (x * 129) / 200;
            int indexZ = (z * 129) / 200;
            //makes them bigger
            temp.transform.localScale = new Vector3(30, 30, 30);
            v3 = temp.transform.localScale;
            //changes their sizes slightly to be larger or smaller 
            float xzVariation = Gaussian(mean,stdDev);
            mean = 10;
            stdDev = 4;
            v3.y = v3.y + Gaussian(mean, stdDev);
            v3.z = v3.z + xzVariation;
            v3.x = v3.x + xzVariation;
            //sets the position
            temp.transform.position = new Vector3(x, (terrain.HeightArray[indexZ, indexX] * terrain.worldSize.y), z);
            temp.transform.localScale = v3;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //uses standard deviations to have a more realistic random
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
