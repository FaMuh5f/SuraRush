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

    [Header("Effect")]
    InstantiatePrefabAsChild InstantiatePrefabAsChild;
    [SerializeField] public ParticleSystem ImmuneEffect;
    [SerializeField] public ParticleSystem SpeedEffect;
    [SerializeField] public ParticleSystem healingEffect;
    

    private bool isSpeedPowerupActive = false;
    private Coroutine powerupCoroutine;
    
    public bool isAlive = true;
    public static bool isInvincible = false;
    public bool isPower = false;
    public Vector3 newPosition;

    private float minX, maxX, minY, maxY;
    private float PlayerWidth, PlayerHeight;
    private float cameraOffsetX;
    private string originalTag;

    Health health;
    AudioPlayer audioPlayer;

    private void Awake() 
    {
        health = FindObjectOfType<Health>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        healingEffect = GetComponent<ParticleSystem>();
        ImmuneEffect = GetComponent<ParticleSystem>();
        SpeedEffect = GetComponent<ParticleSystem>();
        InstantiatePrefabAsChild = FindObjectOfType<InstantiatePrefabAsChild>();
    }

    private void Start()
    {
        // Calculate the camera boundaries
        Camera mainCamera = Camera.main;
        PlayerWidth = GetComponent<SpriteRenderer>().bounds.extents.x;
        PlayerHeight = GetComponent<SpriteRenderer>().bounds.extents.y;
        minX = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + PlayerWidth;
        maxX = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - PlayerWidth;
        minY = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + PlayerHeight;
        maxY = mainCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - PlayerHeight;
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
        newPosition = transform.position + new Vector3(moveHorizontal * GetMoveSpeed() * Time.deltaTime, 
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
            // Move the Player to the new position
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
                InstantiatePrefabAsChild.InstantiatePrefabSpeed();
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
            InstantiatePrefabAsChild.InstantiatePrefabHeal();
            foreach (Transform child in transform) {
                Destroy(child.gameObject,1);
            }
        }

        if (other.CompareTag("InviciblePowerUp"))
        {
            if (!isInvincible)
            {
                isInvincible = true;
                audioPlayer.PlayPowerUpClip();
                powerupCoroutine = StartCoroutine(ActivateInvinciblePowerup());
                Destroy(other.gameObject);
                InstantiatePrefabAsChild.InstantiatePrefabImmune();
            }
        }
    }

    private IEnumerator ActivateSpeedPowerup()
    {
        currentMoveSpeed = 2*normalMoveSpeed;
        InstantiatePrefabAsChild.InstantiatePrefabSpeedEffect();

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
        foreach (Transform child in transform) {
            Destroy(child.gameObject);
        }
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
        InstantiatePrefabAsChild.InstantiatePrefabImmuneEffect();

        yield return new WaitForSeconds(powerupDuration);

        StopCoroutine(powerupCoroutine);
        StartCoroutine(DeactivateInvinciblePowerup());
    }

    private IEnumerator DeactivateInvinciblePowerup()
    {
        isInvincible = false;
        foreach (Transform child in transform) {
                    Destroy(child.gameObject,1);
        }

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

    public Vector3 getPosisition(){
        return newPosition;
    }

    public float getCurrentMoveSpeed(){
        return currentMoveSpeed;
    }
        
    

    // public Vector3 getPlayerTransform()
    // {
    //     return PlayerTransform;
    // }
}