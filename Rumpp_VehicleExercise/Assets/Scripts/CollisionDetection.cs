using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CollisionType
{
    AABB,
    Circle
}

public class CollisionDetection : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static bool AABBCollision(SpriteRenderer a, SpriteRenderer b)
    {
        if (a.bounds.min.x < b.bounds.max.x && a.bounds.max.x > b.bounds.min.x && a.bounds.max.y > b.bounds.min.y && a.bounds.min.y < b.bounds.max.y)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public static bool CircleCollision(SpriteRenderer a, SpriteRenderer b)
    {
        if (Vector2.Distance(a.bounds.center, b.bounds.center) < (a.bounds.size.x + b.bounds.size.x) / 2f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
