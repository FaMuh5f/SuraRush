using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSlide : MonoBehaviour
{
    [SerializeField] float speed = 5f; // Speed of camera movement
    [SerializeField] public bool isGame = false;
    

    private Vector3 startPosition; // Starting position of the camera
    

    void Start()
    {
        startPosition = transform.position; // Stx
    }

    void Update()
    {
        while(isGame)
        {
            // Calculate the new position of the camera based on the current position and the speed
            float newPositionX = (Time.time * speed) % Mathf.Infinity;
            Vector3 newPosition = new Vector3(startPosition.x + newPositionX, transform.position.y, transform.position.z);

            // Update the position of the camera
            transform.position = newPosition;
        }
    }

    public void ResetCamera()
    {
        Vector3 startPosition = new Vector3(0f, 0f, -10f); // Replace with your desired start position
        // Vector3 newPosition = startPosition + new Vector3(0f, 0f, -10f);
        transform.position = startPosition;
    }


    public void setGame(bool parameter)
    {
        isGame = parameter;
    }
}
