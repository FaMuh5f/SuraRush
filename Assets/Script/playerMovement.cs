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
    private bool isSpeedPowerupActive = false;
    private Coroutine powerupCoroutine;
    
    public bool isAlive = true;
    public static bool isInvincible = false;
    public bool isPower = false;

    private float minX, maxX, minY, maxY;
    private float playerWidth, playerHeight;
    private float cameraOffsetX;
    private string originalTag;

    Health health;
    AudioPlayer audioPlayer;

    private void Awake() 
    {
        health = FindObjectOfType<Health>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    private void Start()
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

    private void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        currentMoveSpeed = normalMoveSpeed;
        increasedMoveSpeed = 2*normalMoveSpeed;

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
        return isSpeedPowerupActive ? increasedMoveSpeed : normalMoveSpeed;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SpeedPowerUp"))
        {
            if (!isSpeedPowerupActive)
            {
                isSpeedPowerupActive = true;
                audioPlayer.PlayPowerUpClip();
                powerupCoroutine = StartCoroutine(ActivateSpeedPowerup());
                Destroy(other.gameObject);
            }
        }

        if (other.CompareTag("HealPowerUp"))
        {
            // if (!isPower)
            // {
            //     isPower = true;
            //     powerupCoroutine = StartCoroutine(ActivateHealPowerup());
            //     Destroy(other.gameObject);
                

            // }

            health.heal(10);
            audioPlayer.PlayPowerUpClip();
            Destroy(other.gameObject);
        }

        if (other.CompareTag("InviciblePowerUp"))
        {
            if (!isInvincible)
            {
                isInvincible = true;
                audioPlayer.PlayPowerUpClip();
                powerupCoroutine = StartCoroutine(ActivateInvinciblePowerup());
                Destroy(other.gameObject);
            }
        }
    }

    private IEnumerator ActivateSpeedPowerup()
    {
        currentMoveSpeed = 2*normalMoveSpeed;

        yield return new WaitForSeconds(powerupDuration);

        StopCoroutine(powerupCoroutine);
        StartCoroutine(DeactivateSpeedPowerup());
    }

    private IEnumerator DeactivateSpeedPowerup()
    {
        while (currentMoveSpeed > normalMoveSpeed)
        {
            currentMoveSpeed -= normalMoveSpeedDecreaseRate * Time.deltaTime;
            yield return null;
        }

        currentMoveSpeed = normalMoveSpeed;
        isSpeedPowerupActive = false;
    }

    private IEnumerator ActivateHealPowerup()
    {
        

        yield return new WaitForSeconds(powerupDuration);

        StopCoroutine(powerupCoroutine);
        StartCoroutine(DeactivateHealPowerup());
    }

    private IEnumerator DeactivateHealPowerup()
    {
        gameObject.tag = originalTag;
        isPower = false;

        yield break;
    }

    private IEnumerator ActivateInvinciblePowerup()
    {
        isInvincible = true;

        yield return new WaitForSeconds(powerupDuration);

        StopCoroutine(powerupCoroutine);
        StartCoroutine(DeactivateInvinciblePowerup());
    }

    private IEnumerator DeactivateInvinciblePowerup()
    {
        isInvincible = false;

        yield break;
    }

    public void setAlive(bool parameter)
    {
        isAlive = parameter;
    }

    public static bool getInvicible()
    {
        return isInvincible;
    }

    public void setMovemmentSpeed(float speed){
        normalMoveSpeed = speed;
    }

    // public Vector3 getPlayerTransform()
    // {
    //     return playerTransform;
    // }
}