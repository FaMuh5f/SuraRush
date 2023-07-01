using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    public float moveSpeedVertical = 1f;  // Speed at which the spawner moves vertically
    public float movementRange = 2f;  // Maximum distance the spawner can move vertically

    private bool isMovingUp = true;  // Flag to determine if the spawner is moving up or down

    private Vector3 initialPosition;  // Initial position of the spawner

    private void Start()
    {
        // Store the initial position of the spawner
        initialPosition = transform.position;
        
        StartCoroutine(MoveSpawner());
    }


    private IEnumerator MoveSpawner()
    {
        while (true)
        {

            // Move the spawner vertically
            if (isMovingUp)
                transform.Translate(Vector3.up * moveSpeedVertical * Time.deltaTime);
            else
                transform.Translate(Vector3.down * moveSpeedVertical * Time.deltaTime);

            // Check if the spawner reached the maximum vertical distance
            if (transform.position.y >= movementRange)
                isMovingUp = false;
            else if (transform.position.y <= -movementRange)
                isMovingUp = true;

            yield return null;
        }
    }
}
