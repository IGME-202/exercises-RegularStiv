using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    List<GameObject> gameObjects = new List<GameObject>();
    public GameObject green;
    public GameObject blue;
    public GameObject pink;
    // Start is called before the first frame update
    void Awake()
    {
        gameObjects.Add(Instantiate(green));
        gameObjects.Add(Instantiate(blue));
        gameObjects.Add(Instantiate(pink));
        gameObjects[0].GetComponent<Movement1>().mass = 20;
        gameObjects[1].GetComponent<Movement1>().mass = 5;
        gameObjects[2].GetComponent<Movement1>().mass = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
