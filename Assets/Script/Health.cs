using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] bool isPlayer;
    [SerializeField] int health = 50;
    [SerializeField] int score = 50;

    ScoreKeeper scoreKeeper;
    LevelManager levelManager;

    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        levelManager = FindObjectOfType<LevelManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();

        if(gameObject.CompareTag("Bayi") || gameObject.CompareTag("Remaja"))
        {
            if (other.tag == "Fish")
            {
                Destroy(other.gameObject);
                scoreKeeper.ModifyScore(score);    
            }

            if (other.tag == "MediumFish" && isPlayer)
            {
                TakeDamage(damageDealer.GetDamage());
            }

            if (other.tag == "BigFish" && isPlayer)
            {
                TakeDamage(damageDealer.GetDamage());
            }
        }else if(gameObject.CompareTag("Dewasa") || gameObject.CompareTag("DewasaMatang"))
        {
            if (other.tag == "Fish")
            {
                Destroy(other.gameObject);
                scoreKeeper.ModifyScore(score);    
            }

            if (other.tag == "MediumFish" && isPlayer)
            {
                Destroy(other.gameObject);
                scoreKeeper.ModifyScore(score); 
            }

            if (other.tag == "BigFish" && isPlayer)
            {
                TakeDamage(damageDealer.GetDamage());
            }
        }else if(gameObject.CompareTag("Megalodon"))
        {
            if (other.tag == "Fish")
            {
                Destroy(other.gameObject);
                scoreKeeper.ModifyScore(score);    
            }

            if (other.tag == "MediumFish" && isPlayer)
            {
                Destroy(other.gameObject);
                scoreKeeper.ModifyScore(score); 
            }

            if (other.tag == "BigFish" && isPlayer)
            {
                Destroy(other.gameObject);
                scoreKeeper.ModifyScore(score);
            }
        }
        

        if (other.tag == "Trash")
        {
            // Destroy(other.gameObject);
            TakeDamage(damageDealer.GetDamage());
            damageDealer.Hit();
        }
    }

    public int GetHealth()
    {
        return health;
    }

    void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
            levelManager.LoadGameOver();
            Destroy(gameObject); 
    }
}
