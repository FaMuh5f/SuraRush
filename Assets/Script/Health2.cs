using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health2 : MonoBehaviour
{
    [SerializeField] bool isPlayer2;
    [SerializeField] int health2 = 50;
    [SerializeField] int score2 = 50;
    [SerializeField] float delay2 = 0.5f;
    [SerializeField] float imuneDelay2 = 1f;

    [SerializeField] Animator animator2;

    private bool isInvincible2;

    ScoreKeeper2 scoreKeeper2;
    LevelManager levelManager2;
    playerMovement2 PlayerMovement2;

    void Awake()
    {
        scoreKeeper2 = FindObjectOfType<ScoreKeeper2>();
        levelManager2 = FindObjectOfType<LevelManager>();
        PlayerMovement2 = FindObjectOfType<playerMovement2>();

    }

    void Update() 
    {
        isInvincible2 = playerMovement2.getInvicible();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();

        if(!isInvincible2)
        {
            if(gameObject.CompareTag("Bayi2") || gameObject.CompareTag("Remaja2"))
            {
                if (other.tag == "Fish")
                {
                    animator2.SetBool("isEating",true);
                    animator2.SetBool("isEatingRemaja",true);
                    Destroy(other.gameObject);
                    scoreKeeper2.ModifyScore2(score2);
                    StartCoroutine(ResetIsEating());   
                }

                if (other.tag == "MediumFish" && isPlayer2)
                {
                    animator2.SetBool("isDamage",true);
                    animator2.SetBool("isDamageRemaja",true);
                    TakeDamage(damageDealer.GetDamage());
                    StartCoroutine(ResetIsDamage());
                }

                if (other.tag == "BigFish" && isPlayer2)
                {
                    animator2.SetBool("isDamage",true);
                    animator2.SetBool("isDamageRemaja",true);
                    TakeDamage(damageDealer.GetDamage());
                    StartCoroutine(ResetIsDamage());
                }
            }else if(gameObject.CompareTag("Dewasa2") || gameObject.CompareTag("DewasaMatang2"))
            {
                if (other.tag == "Fish")
                {
                    animator2.SetBool("isEatingDewasa",true);
                    animator2.SetBool("isEatingDewasaMatang",true);
                    Destroy(other.gameObject);
                    scoreKeeper2.ModifyScore2(score2);
                    StartCoroutine(ResetIsEating());    
                }

                if (other.tag == "MediumFish" && isPlayer2)
                {
                    animator2.SetBool("isEatingDewasa",true);
                    animator2.SetBool("isEatingDewasaMatang",true);
                    Destroy(other.gameObject);
                    scoreKeeper2.ModifyScore2(score2);
                    StartCoroutine(ResetIsEating()); 
                }

                if (other.tag == "BigFish" && isPlayer2)
                {
                    animator2.SetBool("isDamageDewasa",true);
                    animator2.SetBool("isDamageDewasaMatang",true);
                    TakeDamage(damageDealer.GetDamage());
                    StartCoroutine(ResetIsDamage());
                }
            }else if(gameObject.CompareTag("Titanochampsa"))
            {
                if (other.tag == "Fish")
                {
                    animator2.SetBool("isEatingMegalodon",true);
                    Destroy(other.gameObject);
                    scoreKeeper2.ModifyScore2(score2);
                    StartCoroutine(ResetIsEating());    
                }

                if (other.tag == "MediumFish" && isPlayer2)
                {
                    animator2.SetBool("isEatingMegalodon",true);
                    Destroy(other.gameObject);
                    scoreKeeper2.ModifyScore2(score2);
                    StartCoroutine(ResetIsEating()); 
                }

                if (other.tag == "BigFish" && isPlayer2)
                {
                    animator2.SetBool("isEatingMegalodon",true);
                    Destroy(other.gameObject);
                    scoreKeeper2.ModifyScore2(score2);
                    StartCoroutine(ResetIsEating());
                }
            }
        
            if (other.tag == "Trash")
            {
                // Destroy(other.gameObject);
                animator2.SetBool("isDamage",true);
                animator2.SetBool("isDamageRemaja",true);
                animator2.SetBool("isDamageDewasa",true);
                animator2.SetBool("isDamageDewasaMatang",true);
                animator2.SetBool("isDamageMegalodon",true);
                TakeDamage(damageDealer.GetDamage());
                damageDealer.Hit();
                StartCoroutine(ResetIsDamage());
            }
        }
    }

    public int GetHealth2()
    {
        return health2;
    }

    void TakeDamage(int damage)
    {
        health2 -= damage;
        if(health2 <= 0)
        {
            Die();
        }
    }

    void Die()
    {
            levelManager2.LoadGameOver();
            animator2.SetBool("isDamage",false);
            animator2.SetBool("isDamageRemaja",false);
            animator2.SetBool("isDamageDewasa",false);
            animator2.SetBool("isDamageDewasaMatang",false);
            animator2.SetBool("isDamageMegalodon",false);
            animator2.SetBool("isDead",true);
            animator2.SetBool("isDeadRemaja",true);
            animator2.SetBool("isDeadDewasa",true);
            animator2.SetBool("isDeadDewasaMatang",true);
            animator2.SetBool("isDeadMegalodon",true);
            PlayerMovement2.setAlive(false);
            // Destroy(gameObject); 
    }

    private IEnumerator ResetIsEating()
    {
        yield return new WaitForSeconds(delay2);
        animator2.SetBool("isEating",false);
        animator2.SetBool("isEatingRemaja",false);
        animator2.SetBool("isEatingDewasa",false);
        animator2.SetBool("isEatingDewasaMatang",false);
        animator2.SetBool("isEatingMegalodon",false);
    }

    private IEnumerator ResetIsDamage()
    {
        yield return new WaitForSeconds(imuneDelay2);
        animator2.SetBool("isDamage",false);
        animator2.SetBool("isDamageRemaja",false);
        animator2.SetBool("isDamageDewasa",false);
        animator2.SetBool("isDamageDewasaMatang",false);
        animator2.SetBool("isDamageMegalodon",false);
    }
}
