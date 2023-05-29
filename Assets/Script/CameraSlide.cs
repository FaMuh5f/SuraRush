using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSlide : MonoBehaviour
{
    [SerializeField] float speed = 5f; // Speed of camera movement

    private Vector3 startPosition; // Starting position of the camera

    void Start()
    {
        startPosition = transform.position; // Store the starting position of the camera
    }

    void Update()
    {
        // Calculate the new position of the camera based on the current position and the speed
        float newPositionX = (Time.time * speed) % Mathf.Infinity;
        Vector3 newPosition = new Vector3(startPosition.x + newPositionX, transform.position.y, transform.position.z);

        // Update the position of the camera
        transform.position = newPosition;
    }
}
