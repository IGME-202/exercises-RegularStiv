using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //starts all vectors
    Vector3 vehiclePosition = new Vector3(0, 0, 0);
    Vector3 direction = new Vector3(1, 0, 0);
    Vector3 velocity = new Vector3(0, 0, 0);
    // Accel vector will calculate the rate of change per second
    Vector3 acceleration = new Vector3(0, 0, 0);
    public float accelerationRate = 0.0001f;
    float vehicleSize = 1.5f;
    // Don’t need a constant speed anymore since the “speed” changes per frame
    // We do need a speed limit!
    public float maximumSpeed = 1f;
    // How fast we want the vehicle to turn
    public float turnSpeed = 1f;
    Vector2 cameraSize;
    // Start is called before the first frame update
    void Start()
    {
        //sets camera size to camera edges
        cameraSize =new Vector2( Camera.main.orthographicSize, Camera.main.orthographicSize * Camera.main.aspect);
    }

    // Update is called once per frame
    void Update()
    {
        // when up arrow is pressed it accellerates
        if (Input.GetKey(KeyCode.UpArrow))
        {
            // Calculate the acceleration vector
            acceleration = direction * accelerationRate;
            // Add acceleration to velocity
            velocity += acceleration;
        }
        // when not pressed it slows to a stop
        else
        {
            velocity -= velocity * accelerationRate;
            StopCar(velocity,.1f);
            // Add acceleration to velocity
        }
        // turrns based on a left or right arrow keys
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // Rotate the direction vector by 1 degree each frame
            direction = Quaternion.Euler(0, 0, turnSpeed) * direction;
            
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            // Rotate the direction vector by 1 degree each frame
            direction = Quaternion.Euler(0, 0, -turnSpeed) * direction;
        }
        

        // Limit the velocity so it doesn’t move too quickly
        velocity = Vector3.ClampMagnitude(velocity, maximumSpeed);
        // Draw the vehicle at that position
        vehiclePosition += velocity;
        //wraps 
        Wrap();

        transform.position = vehiclePosition;
        // Set the vehicle’s rotation to match the direction
        transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
    }

    //stops the car if it is moving slow enough and returns vector 3
    Vector3 StopCar(Vector3 v , float min)
    {
        if (v.sqrMagnitude < min*min)
        {
            v = Vector3.zero;
        }
        return v;
    }

    // wraps the car onto the screen
    void Wrap()
    {
        if (vehiclePosition.x > cameraSize.x + (vehicleSize * 2))
        {
            vehiclePosition.x = -cameraSize.x - vehicleSize;
        }
        else if (vehiclePosition.x < -cameraSize.x - (vehicleSize *2))
        {
            vehiclePosition.x = cameraSize.x + vehicleSize;
        }
        if (vehiclePosition.y > cameraSize.y + (vehicleSize * 2))
        {
            vehiclePosition.y = -cameraSize.y - vehicleSize;
        }
        else if (vehiclePosition.y < -cameraSize.y - (vehicleSize * 2))
        {
            vehiclePosition.y = cameraSize.y + vehicleSize;
        }
    }
}
