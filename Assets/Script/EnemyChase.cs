using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public float speed = 5f; // Adjust this value to control the enemy's movement speed
    public float detectionRadius = 10f; // Adjust this value to control the enemy's detection radius

    private Transform[] players; // Array to store player transforms

    private void Start()
    {
        // Find all player objects with the specified tags and store their transforms in the players array
        if (gameObject.CompareTag("MediumFish"))
        {
            GameObject[] bayiPlayers = GameObject.FindGameObjectsWithTag("Bayi");
            GameObject[] remajaPlayers = GameObject.FindGameObjectsWithTag("Remaja");

            players = new Transform[bayiPlayers.Length + remajaPlayers.Length];

            int index = 0;
            foreach (GameObject playerObject in bayiPlayers)
            {
                players[index++] = playerObject.transform;
            }
            foreach (GameObject playerObject in remajaPlayers)
            {
                players[index++] = playerObject.transform;
            }
        }
        else if (gameObject.CompareTag("BigFish"))
        {
            GameObject[] bayiPlayers = GameObject.FindGameObjectsWithTag("Bayi");
            GameObject[] remajaPlayers = GameObject.FindGameObjectsWithTag("Remaja");
            GameObject[] dewasaPlayers = GameObject.FindGameObjectsWithTag("Dewasa");
            GameObject[] dewasaMatangPlayers = GameObject.FindGameObjectsWithTag("DewasaMatang");

            players = new Transform[bayiPlayers.Length + remajaPlayers.Length + dewasaPlayers.Length + dewasaMatangPlayers.Length];

            int index = 0;
            foreach (GameObject playerObject in bayiPlayers)
            {
                players[index++] = playerObject.transform;
            }
            foreach (GameObject playerObject in remajaPlayers)
            {
                players[index++] = playerObject.transform;
            }
            foreach (GameObject playerObject in dewasaPlayers)
            {
                players[index++] = playerObject.transform;
            }
            foreach (GameObject playerObject in dewasaMatangPlayers)
            {
                players[index++] = playerObject.transform;
            }
        }
    }

    private void Update()
    {
        // Chase each player
        for (int i = 0; i < players.Length; i++)
        {
            ChasePlayer(players[i]);
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
