using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    public SpriteRenderer[] collisionObjects;
    CollisionType collision;
    bool inContact;
    int indexNumber;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        inContact = false;
        if (collision == CollisionType.AABB)
        {
            for (int i = 1; i < collisionObjects.Length; i++)
            {
                if (CollisionDetection.AABBCollision(collisionObjects[0], collisionObjects[i]))
                {
                    inContact = true;
                    indexNumber = i;
                }
            }
        }
        else
        {
            for (int i = 1; i < collisionObjects.Length; i++)
            {
                if (CollisionDetection.CircleCollision(collisionObjects[0], collisionObjects[i]))
                {
                    inContact = true;
                    indexNumber = i;
                }
            }
        }
        if (inContact)
        {

            collisionObjects[indexNumber].color = Color.red;
            collisionObjects[0].color = Color.red;
        }
        else
        {
            for (int i = 0; i < collisionObjects.Length; i++)
            {
                collisionObjects[i].color = Color.white;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha1) && collision != CollisionType.AABB)
        {
            collision = CollisionType.AABB;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && collision != CollisionType.Circle)
        {
            collision = CollisionType.Circle;
        }
    }
}
