using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpenCVForUnityExample;


public class BinController : MonoBehaviour
{
    public FaceDetectionYuNetExample faceDetectionExample;
    public float moveSpeed = 0.5f;
    public float moveRange = 120f;

    private float initialPositionX;

    private void Start()
    {
        if (faceDetectionExample == null)
        {
            Debug.LogError("FaceDetectionYuNetExample reference is not set in FaceMovement script.");
            return;
        }

        // Store the initial position of the object
        initialPositionX = transform.position.x;
        //moveRange = Camera.main.aspect * Camera.main.orthographicSize;
    }

    private void Update()
    {
        // Get the x-coordinate of the detected face from the FaceDetectionYuNetExample script
        float detectedFaceX = faceDetectionExample.GetDetectedFaceXCoordinate();

        if (detectedFaceX != -1)
        {
            //Debug.Log("Detected Face X Coordinate: " + detectedFaceX);

            // Map the x-coordinate of the face to the movement range of the object
            float targetPositionX = Mathf.Clamp(initialPositionX + detectedFaceX * moveSpeed, initialPositionX - moveRange, initialPositionX + moveRange);

            // Update the position of the object
            transform.position = new Vector3(targetPositionX, transform.position.y, transform.position.z);
        }
    }
}