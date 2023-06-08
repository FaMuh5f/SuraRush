using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase2 : MonoBehaviour
{
    public float speed = 5f; // Adjust this value to control the enemy's movement speed
    public float detectionRadius = 10f; // Adjust this value to control the enemy's detection radius
    private Transform player2;
    private Transform playerRemaja2;
    private Transform playerDewasa2;
    private Transform playerDewasaMatang2;
    
    [SerializeField] bool isBigFish = false;

    private void Start()
    {
        player2 = GameObject.FindGameObjectWithTag("Bayi2").transform;
        playerRemaja2 = GameObject.FindGameObjectWithTag("Remaja2").transform;
        playerDewasa2 = GameObject.FindGameObjectWithTag("Dewasa2").transform;
        playerDewasaMatang2 = GameObject.FindGameObjectWithTag("DewasaMatang2").transform;
    }

    private void Update()
    {
        if (!isBigFish)
        {
            ChasePlayer(player2);
            ChasePlayer(playerRemaja2);
        }
        
        if (isBigFish)
        {
            ChasePlayer(player2);
            ChasePlayer(playerRemaja2);
            ChasePlayer(playerDewasa2);
            ChasePlayer(playerDewasaMatang2);
        }
    }

    private void ChasePlayer(Transform target)
    {
        if (target != null && Vector2.Distance(transform.position, target.position) <= detectionRadius)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }
}

