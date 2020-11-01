using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour
{
    public Terrain terrain;
    public void OnGrab()
    {
        transform.position = new Vector3(Random.Range(0, terrain.terrainData.size.x), gameObject.transform.localScale.y / 2, Random.Range(0, terrain.terrainData.size.z));
    }
}
