using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public Camera[] cameras;
    // Current camera 
    private int currentCameraIndex;
    string cameraDescription;
    // Use this for initialization
    void Start()
    {
        currentCameraIndex = 0;
        // Turn all cameras off, except the first default one
        for (int i = 1; i < cameras.Length; i++)
        {
            cameras[i].gameObject.SetActive(false);
        }
        // If any cameras were added to the controller, enable the first one
        if (cameras.Length > 0)
        {
            cameras[0].gameObject.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        // Press the 'C' key to cycle through cameras in the array
        if (Input.GetKeyDown(KeyCode.C))
        {
            // Cycle to the next camera
            currentCameraIndex++;
            // If cameraIndex is in bounds, set this camera active and last one inactive
            if (currentCameraIndex < cameras.Length)
            {
                cameras[currentCameraIndex - 1].gameObject.SetActive(false);
                cameras[currentCameraIndex].gameObject.SetActive(true);
            }
            // If last camera, cycle back to first camera
            else
            {
                cameras[currentCameraIndex - 1].gameObject.SetActive(false);
                currentCameraIndex = 0; 
                cameras[currentCameraIndex].gameObject.SetActive(true);
            }
        }
    }

    // creates the gui in the top left with varying instructions depending on the camera
    private void OnGUI()
    {
        switch (currentCameraIndex)
        {
            case (0):
                cameraDescription = "Terrain Overview";
                break;
            case (1):
                cameraDescription = "Leader Close-Up";
                break;
            case (2):
                cameraDescription = "Horde Mid-Shot";
                break;
            case (3):
                cameraDescription = "Horde Close-Up";
                break;
            case (4):
                cameraDescription = "Terrain Side-View";
                break;
            case (5):
                cameraDescription = "First Person";
                GUI.TextArea(new Rect(0, 0, 200, 70), "Press 'C' to change the camera\nCamera: " + cameraDescription + "\n use the WASD keys to move around");
                break;

        }
        if (currentCameraIndex != 5)
        {
            GUI.TextArea(new Rect(0, 0, 200, 40), "Press 'C' to change the camera\nCamera: " + cameraDescription);
        }
    }
}