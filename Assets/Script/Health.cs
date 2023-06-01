using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] bool isPlayer;
    [SerializeField] int health = 50;
    [SerializeField] int score = 50;
    [SerializeField] float delay = 0.5f;
    [SerializeField] float imuneDelay = 1f;

    [SerializeField] Animator animator;

    ScoreKeeper scoreKeeper;
    LevelManager levelManager;
    playerMovement PlayerMovement;

    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        levelManager = FindObjectOfType<LevelManager>();
        PlayerMovement = FindObjectOfType<playerMovement>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();

        if(gameObject.CompareTag("Bayi") || gameObject.CompareTag("Remaja"))
        {
            if (other.tag == "Fish")
            {
                animator.SetBool("isEating",true);
                Destroy(other.gameObject);
                scoreKeeper.ModifyScore(score);
                StartCoroutine(ResetIsEating());   
            }

            if (other.tag == "MediumFish" && isPlayer)
            {
                animator.SetBool("isDamage",true);
                TakeDamage(damageDealer.GetDamage());
                StartCoroutine(ResetIsDamage());
            }

            if (other.tag == "BigFish" && isPlayer)
            {
                animator.SetBool("isDamage",true);
                TakeDamage(damageDealer.GetDamage());
                StartCoroutine(ResetIsDamage());
            }
        }else if(gameObject.CompareTag("Dewasa") || gameObject.CompareTag("DewasaMatang"))
        {
            if (other.tag == "Fish")
            {
                Destroy(other.gameObject);
                scoreKeeper.ModifyScore(score);
                StartCoroutine(ResetIsEating());    
            }

            if (other.tag == "MediumFish" && isPlayer)
            {
                Destroy(other.gameObject);
                scoreKeeper.ModifyScore(score);
                StartCoroutine(ResetIsEating()); 
            }

            if (other.tag == "BigFish" && isPlayer)
            {
                animator.SetBool("isDamage",true);
                TakeDamage(damageDealer.GetDamage());
                StartCoroutine(ResetIsDamage());
            }
        }else if(gameObject.CompareTag("Megalodon"))
        {
            if (other.tag == "Fish")
            {
                Destroy(other.gameObject);
                scoreKeeper.ModifyScore(score);
                StartCoroutine(ResetIsEating());    
            }

            if (other.tag == "MediumFish" && isPlayer)
            {
                Destroy(other.gameObject);
                scoreKeeper.ModifyScore(score);
                StartCoroutine(ResetIsEating()); 
            }

            if (other.tag == "BigFish" && isPlayer)
            {
                Destroy(other.gameObject);
                scoreKeeper.ModifyScore(score);
                StartCoroutine(ResetIsEating());
            }
        }
        

        if (other.tag == "Trash")
        {
            // Destroy(other.gameObject);
            animator.SetBool("isDamage",true);
            TakeDamage(damageDealer.GetDamage());
            damageDealer.Hit();
            StartCoroutine(ResetIsDamage());
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
            animator.SetBool("isDamage",false);
            animator.SetBool("isDead",true);
            PlayerMovement.setAlive(false);
            // Destroy(gameObject); 
    }

    private IEnumerator ResetIsEating()
    {
        yield return new WaitForSeconds(delay);
        animator.SetBool("isEating", false);
    }

    private IEnumerator ResetIsDamage()
    {
        yield return new WaitForSeconds(imuneDelay);
        animator.SetBool("isDamage", false);
    }
}
