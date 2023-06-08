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

    private bool isInvincible;

    ScoreKeeper scoreKeeper;
    LevelManager levelManager;
    playerMovement PlayerMovement;

    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        levelManager = FindObjectOfType<LevelManager>();
        PlayerMovement = FindObjectOfType<playerMovement>();

    }

    void Update() 
    {
        isInvincible = playerMovement.getInvicible();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();

        if(!isInvincible)
        {
            if(gameObject.CompareTag("Bayi") || gameObject.CompareTag("Remaja"))
            {
                if (other.tag == "Fish")
                {
                    animator.SetBool("isEating",true);
                    animator.SetBool("isEatingRemaja",true);
                    Destroy(other.gameObject);
                    scoreKeeper.ModifyScore(score);
                    StartCoroutine(ResetIsEating());   
                }

                if (other.tag == "MediumFish" && isPlayer)
                {
                    animator.SetBool("isDamage",true);
                    animator.SetBool("isDamageRemaja",true);
                    TakeDamage(damageDealer.GetDamage());
                    StartCoroutine(ResetIsDamage());
                }

                if (other.tag == "BigFish" && isPlayer)
                {
                    animator.SetBool("isDamage",true);
                    animator.SetBool("isDamageRemaja",true);
                    TakeDamage(damageDealer.GetDamage());
                    StartCoroutine(ResetIsDamage());
                }
            }else if(gameObject.CompareTag("Dewasa") || gameObject.CompareTag("DewasaMatang"))
            {
                if (other.tag == "Fish")
                {
                    animator.SetBool("isEatingDewasa",true);
                    animator.SetBool("isEatingDewasaMatang",true);
                    Destroy(other.gameObject);
                    scoreKeeper.ModifyScore(score);
                    StartCoroutine(ResetIsEating());    
                }

                if (other.tag == "MediumFish" && isPlayer)
                {
                    animator.SetBool("isEatingDewasa",true);
                    animator.SetBool("isEatingDewasaMatang",true);
                    Destroy(other.gameObject);
                    scoreKeeper.ModifyScore(score);
                    StartCoroutine(ResetIsEating()); 
                }

                if (other.tag == "BigFish" && isPlayer)
                {
                    animator.SetBool("isDamageDewasa",true);
                    animator.SetBool("isDamageDewasaMatang",true);
                    TakeDamage(damageDealer.GetDamage());
                    StartCoroutine(ResetIsDamage());
                }
            }else if(gameObject.CompareTag("Megalodon"))
            {
                if (other.tag == "Fish")
                {
                    animator.SetBool("isEatingMegalodon",true);
                    Destroy(other.gameObject);
                    scoreKeeper.ModifyScore(score);
                    StartCoroutine(ResetIsEating());    
                }

                if (other.tag == "MediumFish" && isPlayer)
                {
                    animator.SetBool("isEatingMegalodon",true);
                    Destroy(other.gameObject);
                    scoreKeeper.ModifyScore(score);
                    StartCoroutine(ResetIsEating()); 
                }

                if (other.tag == "BigFish" && isPlayer)
                {
                    animator.SetBool("isEatingMegalodon",true);
                    Destroy(other.gameObject);
                    scoreKeeper.ModifyScore(score);
                    StartCoroutine(ResetIsEating());
                }
            }
        
            if (other.tag == "Trash")
            {
                // Destroy(other.gameObject);
                animator.SetBool("isDamage",true);
                animator.SetBool("isDamageRemaja",true);
                animator.SetBool("isDamageDewasa",true);
                animator.SetBool("isDamageDewasaMatang",true);
                animator.SetBool("isDamageMegalodon",true);
                TakeDamage(damageDealer.GetDamage());
                damageDealer.Hit();
                StartCoroutine(ResetIsDamage());
            }
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
            animator.SetBool("isDamageRemaja",false);
            animator.SetBool("isDamageDewasa",false);
            animator.SetBool("isDamageDewasaMatang",false);
            animator.SetBool("isDamageMegalodon",false);
            animator.SetBool("isDead",true);
            animator.SetBool("isDeadRemaja",true);
            animator.SetBool("isDeadDewasa",true);
            animator.SetBool("isDeadDewasaMatang",true);
            animator.SetBool("isDeadMegalodon",true);
            PlayerMovement.setAlive(false);
            // Destroy(gameObject); 
    }

    private IEnumerator ResetIsEating()
    {
        yield return new WaitForSeconds(delay);
        animator.SetBool("isEating",false);
        animator.SetBool("isEatingRemaja",false);
        animator.SetBool("isEatingDewasa",false);
        animator.SetBool("isEatingDewasaMatang",false);
        animator.SetBool("isEatingMegalodon",false);
    }

    private IEnumerator ResetIsDamage()
    {
        yield return new WaitForSeconds(imuneDelay);
        animator.SetBool("isDamage",false);
        animator.SetBool("isDamageRemaja",false);
        animator.SetBool("isDamageDewasa",false);
        animator.SetBool("isDamageDewasaMatang",false);
        animator.SetBool("isDamageMegalodon",false);
    }
}
