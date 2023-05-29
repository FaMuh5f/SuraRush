using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testplayerMovement : MonoBehaviour
{
    public float normalSpeed = 5f; // Normal speed of the player movement
    public float powerUpSpeed = 10f; // Speed of the player movement when powered up
    public float cameraMovementSpeed = 1f; // Speed of the camera movement
    public float powerUpDuration = 5f; // Duration of the power-up in seconds

    private float minX, maxX, minY, maxY;
    private float playerWidth, playerHeight;
    private float cameraOffsetX;
    private bool isPoweredUp = false;
    private float powerUpTimer = 0f;

    void Start()
    {
        // Calculate the camera boundaries
        Camera mainCamera = Camera.main;
        playerWidth = GetComponent<SpriteRenderer>().bounds.extents.x;
        playerHeight = GetComponent<SpriteRenderer>().bounds.extents.y;
        minX = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + playerWidth;
        maxX = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - playerWidth;
        minY = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + playerHeight;
        maxY = mainCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - playerHeight;
    }

    void Update()
    {
        // Get the input for player movement
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        // Calculate the new position
        Vector3 newPosition = transform.position + new Vector3(moveX * GetMoveSpeed() * Time.deltaTime, moveY * GetMoveSpeed() * Time.deltaTime, 0f);

        // Calculate the camera offset based on its movement
        cameraOffsetX += cameraMovementSpeed * Time.deltaTime;

        // Adjust the boundaries based on the camera offset
        float adjustedMinX = minX + cameraOffsetX;
        float adjustedMaxX = maxX + cameraOffsetX;

        // Clamp the new position within the adjusted camera boundaries
        float clampedX = Mathf.Clamp(newPosition.x, adjustedMinX, adjustedMaxX);
        float clampedY = Mathf.Clamp(newPosition.y, minY, maxY);
        newPosition = new Vector3(clampedX, clampedY, 0f);

        // Move the player to the new position
        transform.position = newPosition;

        // Update power-up timer
        if (isPoweredUp)
        {
            powerUpTimer += Time.deltaTime;
            if (powerUpTimer >= powerUpDuration)
            {
                isPoweredUp = false;
                powerUpTimer = 0f;
            }
        }
    }

    float GetMoveSpeed()
    {
        return isPoweredUp ? powerUpSpeed : normalSpeed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PowerUp"))
        {
            isPoweredUp = true;
            // Disable the power-up object
            other.gameObject.SetActive(false);
        }
    }
}
