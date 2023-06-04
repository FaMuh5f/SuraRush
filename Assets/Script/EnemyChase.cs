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

    [SerializeField] bool isBigFish = false;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Bayi").transform;
        playerRemaja = GameObject.FindGameObjectWithTag("Remaja").transform;
        playerDewasa = GameObject.FindGameObjectWithTag("Dewasa").transform;
        playerDewasaMatang = GameObject.FindGameObjectWithTag("DewasaMatang").transform;
    }

    private void Update()
    {
        if (!isBigFish)
        {
            ChasePlayer(player);
            ChasePlayer(playerRemaja);
        }
        
        if (isBigFish)
        {
            ChasePlayer(player);
            ChasePlayer(playerRemaja);
            ChasePlayer(playerDewasa);
            ChasePlayer(playerDewasaMatang);
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
