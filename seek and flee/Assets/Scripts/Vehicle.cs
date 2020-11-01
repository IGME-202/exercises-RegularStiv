using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Vehicle : MonoBehaviour
{
    protected Vector3 position;
    protected Vector3 direction;
    protected Vector3 velocity;
    protected Vector3 acceleration;
    public Terrain terrain;

    [Min(0.0001f)]
    public float mass = 1f;
    public float radius = 1f;
    public float maxSpeed = 1f;
    public float minSpeed = 1f;
    public float maxForce = 5f;


    // Start is called before the first frame update
    void Start()
    {
        terrain.terrainData.size = new Vector3(20, 1, 20);
        position = transform.position;
        direction = Vector3.right;
        velocity = Vector3.zero;
        acceleration = Vector3.zero;
    }
    // Update is called once per frame
    protected virtual void Update()
    {
        ClacSteeringForce();
        Bounce();
        velocity += acceleration * Time.deltaTime;
        position += velocity * Time.deltaTime;
        transform.position = position;
        direction = velocity.normalized;
        acceleration = Vector3.zero;
    }

    protected void ApplyForce(Vector3 force)
    {
        acceleration += force / mass;
    }

    protected abstract void ClacSteeringForce();

    public Vector3 Seek(Vector3 targetPos)
    {
        Vector3 desiredVelocity = targetPos - position;

        desiredVelocity = desiredVelocity.normalized * maxSpeed;

        Vector3 seekingForce = desiredVelocity - velocity;

        seekingForce.y = 0;

        return seekingForce;
    }

    public Vector3 Seek(GameObject obj)
    {
        return Seek(obj.transform.position);
    }

    public Vector3 Flee(Vector3 targetPos)
    {
        Vector3 desiredVelocity = position - targetPos;

        desiredVelocity = desiredVelocity.normalized * maxSpeed;

        Vector3 fleeingForce = desiredVelocity - velocity;

        fleeingForce.y = 0;

        return fleeingForce;
    }

    public Vector3 Flee(GameObject obj)
    {
        return Flee(obj.transform.position);
    }
    void Bounce()
    {
        if (position.x > terrain.terrainData.size.x - gameObject.GetComponent<Collider>().bounds.size.x / 2)
        {
            velocity.x = -velocity.x;
        }
        else if (position.x < 0 + gameObject.GetComponent<Collider>().bounds.size.x / 2)
        {
            velocity.x = -velocity.x;
        }
        if (position.z > terrain.terrainData.size.z - gameObject.GetComponent<Collider>().bounds.size.z / 2)
        {
            velocity.z = -velocity.z;
        }
        else if (position.z < 0 + gameObject.GetComponent<Collider>().bounds.size.z / 2)
        {
            velocity.z = -velocity.z;
        }
    }
}
