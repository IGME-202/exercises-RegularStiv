using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IglooScript : MonoBehaviour
{
    public GameObject igloo;
    // Start is called before the first frame update
    void Start()
    {
       
        igloo = GameObject.Find("bad igloo");
        Instantiate(igloo, new Vector3(19,3,60), Quaternion.Euler(90, 0, 100));
        Instantiate(igloo, new Vector3(75,2,10), Quaternion.Euler(90,90,90));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
