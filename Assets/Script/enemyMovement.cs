using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    public float moveSpeedHorizontal = 1f;  // Speed at which the Fish moves horizontally
    public float moveSpeedVertical = 1f;  // Speed at which the Fish moves vertically
    public float movementRange = 2f;  // Maximum distance the Fish can move vertically

    private bool isMovingUp = true;  // Flag to determine if the Fish is moving up or down

    private Vector3 initialPosition;  // Initial position of the Fish

    private void Start()
    {
        // Create an array of possible movement ranges
        float[] possibleRanges = { -5f, -4f, -3f, 3f, 4f, 5f };

        // Select a random index from the array
        int randomIndex = Random.Range(0, possibleRanges.Length);

        // Assign the selected random movement range
        movementRange = Mathf.Abs(possibleRanges[randomIndex]);

        // Store the initial position of the Fish
        initialPosition = transform.position;
        
        // Start spawning enemies and moving the Fish
        StartCoroutine(moveFish());
    }

    private IEnumerator moveFish()
    {
        // Get the reference to the camera
        Camera mainCamera = Camera.main;

        while (true)
        {
            // Move the Fish horizontally
            transform.Translate(Vector3.right * moveSpeedHorizontal * Time.deltaTime);

            // Get the bottom and top edges of the camera in world coordinates
            float cameraBottom = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, mainCamera.nearClipPlane)).y;
            float cameraTop = mainCamera.ViewportToWorldPoint(new Vector3(0, 1, mainCamera.nearClipPlane)).y;

            // Move the Fish vertically
            float newYPosition = transform.position.y + (isMovingUp ? moveSpeedVertical : -moveSpeedVertical) * Time.deltaTime;

            // Check if the new Y position exceeds the camera bounds
            if (newYPosition < cameraBottom)
            {
                newYPosition = cameraBottom;  // Clamp the position to the bottom of the camera
                isMovingUp = true;  // Start moving up
            }
            else if (newYPosition > cameraTop)
            {
                newYPosition = cameraTop;  // Clamp the position to the top of the camera
                isMovingUp = false;  // Start moving down
            }

            transform.position = new Vector3(transform.position.x, newYPosition, transform.position.z);

            yield return null;
        }
    }
}
