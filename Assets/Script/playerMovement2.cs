using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement2 : MonoBehaviour
{
    [SerializeField]  float normalMoveSpeed2 = 5f;
    [SerializeField]  float increasedMoveSpeed2 = 10f;
    [SerializeField]  float powerupDuration2 = 5f;
    [SerializeField]  float normalMoveSpeedDecreaseRate2 = 5f;
    [SerializeField]  float cameraMovementSpeed2 = 1f;

    [SerializeField] private float currentMoveSpeed2;
    private bool isSpeedPowerupActive2 = false;
    private Coroutine powerupCoroutine2;
    
    public bool isAlive2 = true;
    public static bool isInvincible2 = false;
    public bool isPower2 = false;

    private float minX2, maxX2, minY2, maxY2;
    private float playerWidth2, playerHeight2;
    private float cameraOffsetX2;
    private string originalTag2;

    private void Start()
    {
        currentMoveSpeed2 = normalMoveSpeed2;
        // Calculate the camera boundaries
        Camera mainCamera2 = Camera.main;
        playerWidth2 = GetComponent<SpriteRenderer>().bounds.extents.x;
        playerHeight2 = GetComponent<SpriteRenderer>().bounds.extents.y;
        minX2 = mainCamera2.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + playerWidth2;
        maxX2 = mainCamera2.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - playerWidth2;
        minY2 = mainCamera2.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + playerHeight2;
        maxY2 = mainCamera2.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - playerHeight2;
    }

    private void Update()
    {
        // Update moveHorizontal2 and moveVertical2 based on input
        float moveHorizontal2 = 0f;
        float moveVertical2 = 0f;

        if (Input.GetKey(KeyCode.I))
        {
            moveVertical2 = 1f; // Up
        }
        else if (Input.GetKey(KeyCode.J))
        {
            moveHorizontal2 = -1f; // Left
        }
        else if (Input.GetKey(KeyCode.K))
        {
            moveVertical2 = -1f; // Down
        }
        else if (Input.GetKey(KeyCode.L))
        {
            moveHorizontal2 = 1f; // Right
        }

        // Calculate the new position
        Vector3 newPosition2 = transform.position + new Vector3(moveHorizontal2 * GetMoveSpeed() * Time.deltaTime, 
        moveVertical2 * GetMoveSpeed() * Time.deltaTime, 0f);

        // Calculate the camera offset based on its movement
        cameraOffsetX2 += cameraMovementSpeed2 * Time.deltaTime;

        // Adjust the boundaries based on the camera offset
        float adjustedMinX2 = minX2 + cameraOffsetX2;
        float adjustedMaxX2 = maxX2 + cameraOffsetX2;

        // Clamp the new position within the adjusted camera boundaries
        float clampedX2 = Mathf.Clamp(newPosition2.x, adjustedMinX2, adjustedMaxX2);
        float clampedY2 = Mathf.Clamp(newPosition2.y, minY2, maxY2);
        newPosition2 = new Vector3(clampedX2, clampedY2, 0f);

        if (isAlive2)
        {
            // Move the player to the new position
            transform.position = newPosition2;
        }
    }

    float GetMoveSpeed()
    {
        return isSpeedPowerupActive2 ? increasedMoveSpeed2 : normalMoveSpeed2;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SpeedPowerUp"))
        {
            if (!isSpeedPowerupActive2)
            {
                isSpeedPowerupActive2 = true;
                powerupCoroutine2 = StartCoroutine(ActivateSpeedPowerup());
                Destroy(other.gameObject);
            }
        }

        if (other.CompareTag("PowerPowerUp"))
        {
            if (!isPower2)
            {
                isPower2 = true;
                powerupCoroutine2 = StartCoroutine(ActivatePowerPowerup());
                Destroy(other.gameObject);
            }
        }

        if (other.CompareTag("InvinciblePowerUp"))
        {
            if (!isInvincible2)
            {
                isInvincible2 = true;
                powerupCoroutine2 = StartCoroutine(ActivateInvinciblePowerup());
                Destroy(other.gameObject);
            }
        }
    }

    private IEnumerator ActivateSpeedPowerup()
    {
        currentMoveSpeed2 = increasedMoveSpeed2;

        yield return new WaitForSeconds(powerupDuration2);

        StopCoroutine(powerupCoroutine2);
        StartCoroutine(DeactivateSpeedPowerup());
    }

    private IEnumerator DeactivateSpeedPowerup()
    {
        while (currentMoveSpeed2 > normalMoveSpeed2)
        {
            currentMoveSpeed2 -= normalMoveSpeedDecreaseRate2 * Time.deltaTime;
            yield return null;
        }

        currentMoveSpeed2 = normalMoveSpeed2;
        isSpeedPowerupActive2 = false;
    }

    private IEnumerator ActivatePowerPowerup()
    {
        originalTag2 = gameObject.tag;

        gameObject.tag = "Megalodon";

        yield return new WaitForSeconds(powerupDuration2);

        StopCoroutine(powerupCoroutine2);
        StartCoroutine(DeactivatePowerPowerup());
    }

    private IEnumerator DeactivatePowerPowerup()
    {
        gameObject.tag = originalTag2;
        isPower2 = false;

        yield break;
    }

    private IEnumerator ActivateInvinciblePowerup()
    {
        isInvincible2 = true;

        yield return new WaitForSeconds(powerupDuration2);

        StopCoroutine(powerupCoroutine2);
        StartCoroutine(DeactivateInvinciblePowerup());
    }

    private IEnumerator DeactivateInvinciblePowerup()
    {
        isInvincible2 = false;

        yield break;
    }

    public void setAlive(bool parameter)
    {
        isAlive2 = parameter;
    }

    public static bool getInvicible()
    {
        return isInvincible2;
    }
}