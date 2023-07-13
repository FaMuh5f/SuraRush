using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;  // Array of enemy prefabs
    public float spawnInterval = 2f;  // Time interval between each enemy spawn
    public float moveSpeedHorizontal = 1f;  // Speed at which the spawner moves horizontally
    public float moveSpeedVertical = 1f;  // Speed at which the spawner moves vertically
    public float movementRange = 2f;  // Maximum distance the spawner can move vertically
    public int maxEnemies = 10;  // Maximum number of enemies to be spawned
    private float spawnIntervalFirst = 1f; // Time interval before spawn fish

    private int spawnedEnemies = 0;  // Counter for spawned enemies
    private bool isMovingUp = true;  // Flag to determine if the spawner is moving up or down

    private Vector3 initialPosition;  // Initial position of the spawner

    private void Start()
    {
        // Create an array of possible movement ranges
        float[] possibleRanges = { -1f, 1f };

        // Select a random index from the array
        int randomIndex = Random.Range(0, possibleRanges.Length);

        // Assign the selected random movement range
        moveSpeedVertical = Mathf.Abs(possibleRanges[randomIndex]);

        // set spawn for the first time as random from 3s to 5s
        spawnIntervalFirst = Random.Range(0f, 3f);

        // Store the initial position of the spawner
        initialPosition = transform.position;
        
        // Start spawning enemies and moving the spawner
        StartCoroutine(SpawnEnemies());
        StartCoroutine(MoveSpawner());
    }

    private IEnumerator SpawnEnemies()
    {
        // Add a delay before starting the spawning
        yield return new WaitForSeconds(spawnIntervalFirst);

        while (true)
        {
            // Select a random enemy prefab from the array
            GameObject randomEnemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

            // Spawn enemy
            GameObject newEnemy = Instantiate(randomEnemyPrefab, transform.position, Quaternion.identity);

            // Increment the counter
            spawnedEnemies++;

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private IEnumerator MoveSpawner()
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

    private void Update()
    {
        // Check if any enemies have moved past the left side of the camera
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Fish");
        GameObject[] mediumEnemies = GameObject.FindGameObjectsWithTag("MediumFish");
        GameObject[] bigEnemies = GameObject.FindGameObjectsWithTag("BigFish");
        GameObject[] trashes = GameObject.FindGameObjectsWithTag("Trash");
        GameObject[] powerUps = GameObject.FindGameObjectsWithTag("SpeedPowerUp");
        GameObject[] powerPowerUps = GameObject.FindGameObjectsWithTag("PowerPowerUp");
        GameObject[] inviciblePowerUps = GameObject.FindGameObjectsWithTag("InviciblePowerUp");
        foreach (GameObject enemy in enemies)
        {
            Vector3 enemyScreenPos = Camera.main.WorldToScreenPoint(enemy.transform.position);
            if (enemyScreenPos.x < 0)
            {
                // Destroy enemy if it's past the left side of the camera
                Destroy(enemy);
                spawnedEnemies--;
            }
        }

        foreach (GameObject enemy in mediumEnemies)
        {
            Vector3 enemyScreenPos = Camera.main.WorldToScreenPoint(enemy.transform.position);
            if (enemyScreenPos.x < 0)
            {
                // Destroy enemy if it's past the left side of the camera
                Destroy(enemy);
                spawnedEnemies--;
            }
        }

        foreach (GameObject enemy in bigEnemies)
        {
            Vector3 enemyScreenPos = Camera.main.WorldToScreenPoint(enemy.transform.position);
            if (enemyScreenPos.x < 0)
            {
                // Destroy enemy if it's past the left side of the camera
                Destroy(enemy);
                spawnedEnemies--;
            }
        }

        foreach (GameObject enemy in trashes)
        {
            Vector3 enemyScreenPos = Camera.main.WorldToScreenPoint(enemy.transform.position);
            if (enemyScreenPos.x < 0)
            {
                // Destroy enemy if it's past the left side of the camera
                Destroy(enemy);
                spawnedEnemies--;
            }
        }

        foreach (GameObject enemy in powerUps)
        {
            Vector3 enemyScreenPos = Camera.main.WorldToScreenPoint(enemy.transform.position);
            if (enemyScreenPos.x < 0)
            {
                // Destroy enemy if it's past the left side of the camera
                Destroy(enemy);
                spawnedEnemies--;
            }
        }

        foreach (GameObject enemy in powerPowerUps)
        {
            Vector3 enemyScreenPos = Camera.main.WorldToScreenPoint(enemy.transform.position);
            if (enemyScreenPos.x < 0)
            {
                // Destroy enemy if it's past the left side of the camera
                Destroy(enemy);
                spawnedEnemies--;
            }
        }

        foreach (GameObject enemy in inviciblePowerUps)
        {
            Vector3 enemyScreenPos = Camera.main.WorldToScreenPoint(enemy.transform.position);
            if (enemyScreenPos.x < 0)
            {
                // Destroy enemy if it's past the left side of the camera
                Destroy(enemy);
                spawnedEnemies--;
            }
        }
    }

    public void ResetSpawner()
    {
        // Reset the position of the spawner to its initial position
        transform.position = initialPosition;

        // Reset any other variables or states if needed
        spawnedEnemies = 0;
        isMovingUp = true;
    }
}
