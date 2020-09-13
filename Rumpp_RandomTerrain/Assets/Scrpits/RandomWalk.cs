using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWalk : MonoBehaviour
{
    public GameObject walker;
    private bool pressedM;
    // Start is called before the first frame update
    void Start()
    {
        pressedM = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!pressedM && Input.GetKeyDown("m"))
        {
            pressedM = true;
        }
        else if (pressedM && Input.GetKeyDown("m"))
        {
            pressedM = false;
        }
        if (pressedM)
        {
            Walk();
        }
    }

    void Walk()
    {
            walker.transform.Translate(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
    }
}
