using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public float speed = 5f; // Adjust this value to control the enemy's movement speed
    public float detectionRadius = 10f; // Adjust this value to control the enemy's detection radius
    private Transform player;
    private Transform playerRemaja;
    private Transform playerDewasa;
    private Transform playerDewasaMatang;

    private bool isBigFish = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Bayi").transform;
        playerRemaja = GameObject.FindGameObjectWithTag("Remaja").transform;
        playerDewasa = GameObject.FindGameObjectWithTag("Dewasa").transform;
        playerDewasaMatang = GameObject.FindGameObjectWithTag("DewasaMatang").transform;

        if (gameObject.CompareTag("BigFish"))
        {
            isBigFish = true;
        }
    }

    private void Update()
    {
        if(!isBigFish)
        {
            // Check if the player is within the detection radius
            if (Vector2.Distance(transform.position, player.position) <= detectionRadius)
            {
                // Move towards the player
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }

            // Check if the player is within the detection radius
            else if (Vector2.Distance(transform.position, playerRemaja.position) <= detectionRadius)
            {
                // Move towards the player
                transform.position = Vector2.MoveTowards(transform.position, playerRemaja.position, speed * Time.deltaTime);
            }
        }
        else if(isBigFish)
        {
            // Check if the player is within the detection radius
            if (Vector2.Distance(transform.position, player.position) <= detectionRadius)
            {
                // Move towards the player
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }

            // Check if the player is within the detection radius
            else if (Vector2.Distance(transform.position, playerRemaja.position) <= detectionRadius)
            {
                // Move towards the player
                transform.position = Vector2.MoveTowards(transform.position, playerRemaja.position, speed * Time.deltaTime);
            }

            // Check if the player is within the detection radius
            else if (Vector2.Distance(transform.position, playerDewasa.position) <= detectionRadius)
            {
                // Move towards the player
                transform.position = Vector2.MoveTowards(transform.position, playerDewasa.position, speed * Time.deltaTime);
            }

            // Check if the player is within the detection radius
            else if (Vector2.Distance(transform.position, playerDewasaMatang.position) <= detectionRadius)
            {
                // Move towards the player
                transform.position = Vector2.MoveTowards(transform.position, playerDewasaMatang.position, speed * Time.deltaTime);
            }
        }
    }
}
