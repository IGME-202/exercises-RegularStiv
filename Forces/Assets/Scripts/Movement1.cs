using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Movement1 : MonoBehaviour
{
    //starts all vectors
    bool friction = false;
    Vector3 vehiclePosition = new Vector3(0, 0, 0);
    Vector3 direction = new Vector3(1, 0, 0);
    Vector3 velocity = new Vector3(0, 0, 0);
    // Accel vector will calculate the rate of change per second
    Vector3 acceleration = new Vector3(0, 0, 0);
    public float accelerationRate;
    public float mass;
    float vehicleSize = 1.5f;
    float turnSpeed = 1f;
    Vector2 cameraSize;
    // Start is called before the first frame update
    void Start()
    {
        //sets camera size to camera edges
        cameraSize = new Vector2(Camera.main.orthographicSize, Camera.main.orthographicSize * Camera.main.aspect);
        vehiclePosition = new Vector3(Random.Range(-cameraSize.x + 2,cameraSize.x - 2), Random.Range(-cameraSize.y + 4 ,cameraSize.y - 4), 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        //calls all methods and zeros acceleration
        acceleration = Vector3.zero;
        if (velocity.sqrMagnitude > 0 && friction)
        {
            ApplyFriction(2);
        }
        ApplyMouseForce();
        TurnVehicle();
        Bounce();
        UpdateVehicle();

        transform.position = vehiclePosition;
        // Set the vehicle’s rotation to match the direction
        transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);

        if (Input.GetKeyDown(KeyCode.F))
        {
            friction = !friction;
        }
    }
    // updates the vehicle's loaction 
    void UpdateVehicle()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            ApplyForce(direction * accelerationRate);
        }
        else
        {
            velocity = velocity * .95f;
            if (velocity.sqrMagnitude < .00001)
            {
                velocity = Vector3.ClampMagnitude(velocity, 0);
            }
        }
        velocity += acceleration * Time.deltaTime;
        vehiclePosition += velocity * Time.deltaTime;
    }
    // applies friction 
    void ApplyFriction(float coeff)
    {
        Vector3 friction = velocity * -1;
        friction.Normalize();
        friction = friction * coeff;
        ApplyForce(friction);
    }

    //takes the mouse location and the location of the monsters and applies a force based on that
    void ApplyMouseForce()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 force = new Vector3(mousePos.x - gameObject.transform.position.x, mousePos.y - gameObject.transform.position.y , 0);
            ApplyForce(force);
        }
    }

    void TurnVehicle()
    {
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
    }
    void ApplyForce(Vector3 force)
    {
        acceleration += force / mass;
    }

    //makes the objects bounce off of the sides of the screen 
    void Bounce()
    {
        if (vehiclePosition.x > cameraSize.x)
        {
            velocity.x = -velocity.x;
        }
        else if (vehiclePosition.x < -cameraSize.x)
        {
            velocity.x = -velocity.x;
        }
        if (vehiclePosition.y > cameraSize.y - 3)
        {
            velocity.y = -velocity.y;
        }
        else if (vehiclePosition.y < -cameraSize.y + 3)
        {
            velocity.y = -velocity.y;
        }
    }
    // wraps the objects onto the screen
    void Wrap()
    {
        if (vehiclePosition.x > cameraSize.x + (vehicleSize * 2))
        {
            vehiclePosition.x = -cameraSize.x - vehicleSize;
        }
        else if (vehiclePosition.x < -cameraSize.x - (vehicleSize * 2))
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
