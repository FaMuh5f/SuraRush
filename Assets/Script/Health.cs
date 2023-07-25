using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] bool isPlayer;
    [SerializeField] int health = 50;
    // [SerializeField] int score = 50;
    [SerializeField] float delay = 0.5f;
    [SerializeField] float imuneDelay = 1f;
    [SerializeField] Animator animator;
    [SerializeField] int fishScore = 200;
    [SerializeField] int mediumFishScore = 300;
    [SerializeField] int bigFishScore = 500; 

    private bool isInvincible;
    private int yummy;

    AudioPlayer audioPlayer;
    ScoreKeeper scoreKeeper;
    LevelManager levelManager;
    playerMovement PlayerMovement;
    ParticleSystem eatEffect;

    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        levelManager = FindObjectOfType<LevelManager>();
        PlayerMovement = FindObjectOfType<playerMovement>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        eatEffect = GetComponent<ParticleSystem>();

    }

    void Update() 
    {
        isInvincible = playerMovement.getInvicible();
        yummy = scoreKeeper.GetScore() % 500;
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
                    scoreKeeper.ModifyScore(fishScore);
                    if(yummy <= 100){
                        audioPlayer.PlayYummyClip();
                        eatEffect.Play();
                        Debug.Log("Yummy");
                    }else{
                        audioPlayer.PlayEatingClip();
                    }
                    Destroy(other.gameObject);
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
                    scoreKeeper.ModifyScore(fishScore);
                    if(yummy <= 100){
                        audioPlayer.PlayYummyClip();
                        eatEffect.Play();
                        Debug.Log("Yummy");
                    }else{
                        audioPlayer.PlayEatingClip();
                    }
                    Destroy(other.gameObject);
                    StartCoroutine(ResetIsEating());    
                }

                if (other.tag == "MediumFish" && isPlayer)
                {
                    animator.SetBool("isEatingDewasa",true);
                    animator.SetBool("isEatingDewasaMatang",true);
                    scoreKeeper.ModifyScore(mediumFishScore);
                    if(yummy <= 100){
                        audioPlayer.PlayYummyClip();
                        eatEffect.Play();
                        Debug.Log("Yummy");
                    }else{
                        audioPlayer.PlayEatingClip();
                    }
                    Destroy(other.gameObject);
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
                    scoreKeeper.ModifyScore(fishScore);
                    if(yummy <= 100){
                        audioPlayer.PlayYummyClip();
                        eatEffect.Play();
                        Debug.Log("Yummy");
                    }else{
                        audioPlayer.PlayEatingClip();
                    }
                    Destroy(other.gameObject);
                    StartCoroutine(ResetIsEating());    
                }

                if (other.tag == "MediumFish" && isPlayer)
                {
                    animator.SetBool("isEatingMegalodon",true);
                    scoreKeeper.ModifyScore(mediumFishScore);
                    if(yummy <= 100){
                        audioPlayer.PlayYummyClip();
                        eatEffect.Play();
                        Debug.Log("Yummy");
                    }else{
                        audioPlayer.PlayEatingClip();
                    }
                    Destroy(other.gameObject);
                    StartCoroutine(ResetIsEating()); 
                }

                if (other.tag == "BigFish" && isPlayer)
                {
                    animator.SetBool("isEatingMegalodon",true);
                    scoreKeeper.ModifyScore(bigFishScore);
                    eatEffect.Play();
                    if(yummy <= 100){
                        audioPlayer.PlayYummyClip();
                        eatEffect.Play();
                        Debug.Log("Yummy");
                    }else{
                        audioPlayer.PlayEatingClip();
                    }
                    Destroy(other.gameObject);
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
        health = Mathf.Max(health, 0);
        if(health <= 0)
        {
            isPlayer = false;
            Die();
        }
    }

    // void addScore(int score1)
    // {
    //     if(!isPlayer)
    //     {
    //         scoreKeeper.ModifyScore(score1);
    //     }
    // }

    void Die()
    {
        audioPlayer.PlayDeathClip();
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
    }

    private IEnumerator ResetIsEating()
    {
        yield return new WaitForSeconds(delay);
        animator.SetBool("isEating",false);
        animator.SetBool("isEatingRemaja",false);
        animator.SetBool("isEatingDewasa",false);
        animator.SetBool("isEatingDewasaMatang",false);
        animator.SetBool("isEatingMegalodon",false);
        eatEffect.Stop();
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

    public bool GetPlayer()
    {
        return isPlayer;
    }

    public void heal(int value)
    {
        health += value;
        if(health > 100)
        {
            health = 100;
        }
    }
}
