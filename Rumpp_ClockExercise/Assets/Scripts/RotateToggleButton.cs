using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToggleButton : MonoBehaviour
{
    public GameObject hand;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        hand.GetComponent<RotateHand>().toggle = !hand.GetComponent<RotateHand>().toggle;
    }
}
