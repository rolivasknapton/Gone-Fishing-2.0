using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public Transform mainCameraTransform;
    public Vector3 targetPosition;
    private float lerpDuration = 0.5f;
    private float lerpStartTime;

    public float lerpProgress;

    void Start()
    {
        // Initialize the target position with the current camera position
        targetPosition = mainCameraTransform.position;
    }

    void Update()
    {
        // Check if lerping is in progress
        if (Time.time - lerpStartTime < lerpDuration)
        {
            
            // Calculate lerp percentage
            lerpProgress = (Time.time - lerpStartTime) / lerpDuration;
            // Apply the lerp to the camera position
            mainCameraTransform.position = Vector3.Lerp(mainCameraTransform.position, targetPosition, lerpProgress);
        }
        
    }

    // Method to initiate lerping to a new position
    public void LerpToPosition(Vector3 newPosition)
    {
        //Debug.Log("gay");
        // Set the target position to the new position
        targetPosition = newPosition;
        // Set the lerp start time to the current time
        lerpStartTime = Time.time;
    }
}

