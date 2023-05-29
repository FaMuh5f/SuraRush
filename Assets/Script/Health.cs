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

        if (other.tag == "Fish")
        {
            Destroy(other.gameObject);
            scoreKeeper.ModifyScore(score);    
        }

        if (other.tag == "Trash")
        {
            Destroy(other.gameObject);
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
            // levelManager.LoadGameOver();
            Destroy(gameObject); 
    }
}
