using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRun : MonoBehaviour
{
    public float speed = 5f; // Adjust this value to control the enemy's movement speed
    public float detectionRadius = 10f; // Adjust this value to control the enemy's detection radius
    private Transform player;
    private Transform playerRemaja;
    private Transform playerDewasa;
    private Transform playerDewasaMatang;
    private Transform playerMegalodon;

    [SerializeField] bool isMediumFish = false;
    [SerializeField] bool isBigFish = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Bayi").transform;
        playerRemaja = GameObject.FindGameObjectWithTag("Remaja").transform;
        playerDewasa = GameObject.FindGameObjectWithTag("Dewasa").transform;
        playerDewasaMatang = GameObject.FindGameObjectWithTag("DewasaMatang").transform;
        playerMegalodon = GameObject.FindGameObjectWithTag("Megalodon").transform;
    }

    private void Update()
    {
        if(!isMediumFish && !isBigFish)
        {
            runAway(player);
            runAway(playerRemaja);
            runAway(playerDewasa);
            runAway(playerDewasaMatang);
            runAway(playerMegalodon);
        }
        if (!isBigFish && isMediumFish)
        {
            runAway(playerDewasa);
            runAway(playerDewasaMatang);
            runAway(playerMegalodon);
        }
        else if (isBigFish && !isMediumFish)
        {
            runAway(playerMegalodon);
        }
    }

    private void runAway(Transform target)
    {
        if (target != null && Vector2.Distance(transform.position, target.position) <= detectionRadius)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, -speed * Time.deltaTime);
        }
    }
}
