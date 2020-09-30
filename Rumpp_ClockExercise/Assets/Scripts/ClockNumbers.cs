using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockNumbers : MonoBehaviour
{
    public GameObject numbers;
    GameObject[] numberArray;
    // Start is called before the first frame update
    void Start()
    {
        numberArray = new GameObject[12];
        for (int i = 0; i < numberArray.Length; i++) 
        {
            numberArray[i] = Instantiate(numbers, new Vector3(2.3f * Mathf.Cos(((i + 2) * Mathf.PI) / 6), 2.3f * Mathf.Sin(((i + 2) * Mathf.PI) / 6)), new Quaternion(0,0,0,0));
            int number = 12 - i;
            numbers.GetComponentInChildren<TextMesh>().text = number.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
