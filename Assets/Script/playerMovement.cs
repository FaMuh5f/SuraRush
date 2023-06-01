using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [SerializeField]  float normalMoveSpeed = 5f;
    [SerializeField]  float increasedMoveSpeed = 10f;
    [SerializeField]  float powerupDuration = 5f;
    [SerializeField]  float normalMoveSpeedDecreaseRate = 5f;
    [SerializeField]  float cameraMovementSpeed = 1f;

    [SerializeField] private float currentMoveSpeed;
    private bool isPowerupActive = false;
    private Coroutine powerupCoroutine;
    
    public bool isAlive = true;

    private float minX, maxX, minY, maxY;
    private float playerWidth, playerHeight;
    private float cameraOffsetX;

    private void Start()
    {
        currentMoveSpeed = normalMoveSpeed;
        // Calculate the camera boundaries
        Camera mainCamera = Camera.main;
        playerWidth = GetComponent<SpriteRenderer>().bounds.extents.x;
        playerHeight = GetComponent<SpriteRenderer>().bounds.extents.y;
        minX = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + playerWidth;
        maxX = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - playerWidth;
        minY = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + playerHeight;
        maxY = mainCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - playerHeight;
    }

    private void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0f);
        // transform.position += movement * currentMoveSpeed * Time.deltaTime;

        // Calculate the new position
        Vector3 newPosition = transform.position + new Vector3(moveHorizontal * GetMoveSpeed() * Time.deltaTime, 
        moveVertical * GetMoveSpeed() * Time.deltaTime, 0f);

        // Calculate the camera offset based on its movement
        cameraOffsetX += cameraMovementSpeed * Time.deltaTime;

        // Adjust the boundaries based on the camera offset
        float adjustedMinX = minX + cameraOffsetX;
        float adjustedMaxX = maxX + cameraOffsetX;

        // Clamp the new position within the adjusted camera boundaries
        float clampedX = Mathf.Clamp(newPosition.x, adjustedMinX, adjustedMaxX);
        float clampedY = Mathf.Clamp(newPosition.y, minY, maxY);
        newPosition = new Vector3(clampedX, clampedY, 0f);

        if (isAlive)
        {
        // Move the player to the new position
        transform.position = newPosition;
        }
    }

    float GetMoveSpeed()
    {
        return isPowerupActive ? increasedMoveSpeed : normalMoveSpeed;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PowerUp"))
        {
            if (!isPowerupActive)
            {
                isPowerupActive = true;
                powerupCoroutine = StartCoroutine(ActivatePowerup());
                Destroy(other.gameObject);
            }
        }
    }

    private IEnumerator ActivatePowerup()
    {
        currentMoveSpeed = increasedMoveSpeed;

        yield return new WaitForSeconds(powerupDuration);

        StopCoroutine(powerupCoroutine);
        StartCoroutine(DeactivatePowerup());
    }

    private IEnumerator DeactivatePowerup()
    {
        while (currentMoveSpeed > normalMoveSpeed)
        {
            currentMoveSpeed -= normalMoveSpeedDecreaseRate * Time.deltaTime;
            yield return null;
        }

        currentMoveSpeed = normalMoveSpeed;
        isPowerupActive = false;
    }

    public void setAlive(bool parameter)
    {
        isAlive = parameter;
    }
}