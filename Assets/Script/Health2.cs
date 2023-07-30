using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health2 : MonoBehaviour
{
    [SerializeField] bool isPlayer2;
    [SerializeField] int health2 = 50;
    // [SerializeField] int score2 = 50;
    [SerializeField] float delay2 = 0.5f;
    [SerializeField] float immuneDelay2 = 1f;
    // [SerializeField] Animator animator;
    [SerializeField] int fishScore = 200;
    [SerializeField] int mediumFishScore = 300;
    [SerializeField] int bigFishScore = 500;

    // [SerializeField] Animator animator2;

    private bool isInvincible2;
    private bool isYummy = false;

    AudioPlayer2 audioPlayer2;
    ScoreKeeper2 scoreKeeper2;
    LevelManager levelManager;
    playerMovement2 playerMovement2;

    [Header("Effect")]
    InstantiatePrefabAsChild2 InstantiatePrefabAsChild2;

    void Awake()
    {
        scoreKeeper2 = FindObjectOfType<ScoreKeeper2>();
        levelManager = FindObjectOfType<LevelManager>();
        playerMovement2 = FindObjectOfType<playerMovement2>();
        audioPlayer2 = FindObjectOfType<AudioPlayer2>();
        // eatEffect = GetComponent<ParticleSystem>();
        InstantiatePrefabAsChild2 = FindObjectOfType<InstantiatePrefabAsChild2>();
        
    }

    void Update()
    {
        isInvincible2 = playerMovement2.getInvicible();
        isYummy = scoreKeeper2.GetScore() % 500 == 0;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();

        if(gameObject.CompareTag("Bayi2") || gameObject.CompareTag("Remaja2"))
        {
            if (other.tag == "Fish")
            {
                scoreKeeper2.ModifyScore(fishScore);
                if(isYummy){
                    audioPlayer2.PlayYummyClip();
                    InstantiatePrefabAsChild2.InstantiatePrefabEat();
                }else{
                    audioPlayer2.PlayEatingClip();
                }
                Destroy(other.gameObject);
                StartCoroutine(ResetIsEating());
                
            }

            if (other.tag == "MediumFish" && isPlayer2)
            {
                audioPlayer2.PlayHitClip();
                TakeDamage(damageDealer.GetDamage());
                StartCoroutine(ResetIsDamage());
            }

            if (other.tag == "BigFish" && isPlayer2)
            {
                audioPlayer2.PlayHitClip();
                TakeDamage(damageDealer.GetDamage());
                StartCoroutine(ResetIsDamage());
            }
        }else if(gameObject.CompareTag("Dewasa2") || gameObject.CompareTag("DewasaMatang2"))
        {
            if (other.tag == "Fish")
            {

                scoreKeeper2.ModifyScore(fishScore);
                if(isYummy){
                    audioPlayer2.PlayYummyClip();
                    InstantiatePrefabAsChild2.InstantiatePrefabEat();
                    Debug.Log(isYummy);
                }else{
                    audioPlayer2.PlayEatingClip();
                }
                Destroy(other.gameObject);
                StartCoroutine(ResetIsEating());    
            }

            if (other.tag == "MediumFish" && isPlayer2)
            {
            
                scoreKeeper2.ModifyScore(mediumFishScore);
                if(isYummy){
                    audioPlayer2.PlayYummyClip();
                    InstantiatePrefabAsChild2.InstantiatePrefabEat();
                    Debug.Log(isYummy);
                }else{
                    audioPlayer2.PlayEatingClip();
                }
                Destroy(other.gameObject);
                StartCoroutine(ResetIsEating()); 
            }

            if (other.tag == "BigFish" && isPlayer2)
            {
                audioPlayer2.PlayHitClip();
                TakeDamage(damageDealer.GetDamage());
                StartCoroutine(ResetIsDamage());
            }
        }else if(gameObject.CompareTag("Titanochampsa"))
        {
            if (other.tag == "Fish")
            {
                scoreKeeper2.ModifyScore(fishScore);
                if(isYummy){
                    audioPlayer2.PlayYummyClip();
                    InstantiatePrefabAsChild2.InstantiatePrefabEat();
                    Debug.Log(isYummy);
                }else{
                    audioPlayer2.PlayEatingClip();
                }
                Destroy(other.gameObject);
                StartCoroutine(ResetIsEating());    
            }

            if (other.tag == "MediumFish" && isPlayer2)
            {
                scoreKeeper2.ModifyScore(mediumFishScore);
                if(isYummy){
                    audioPlayer2.PlayYummyClip();
                    InstantiatePrefabAsChild2.InstantiatePrefabEat();
                    Debug.Log(isYummy);
                }else{
                    audioPlayer2.PlayEatingClip();
                }
                Destroy(other.gameObject);
                StartCoroutine(ResetIsEating()); 
            }

            if (other.tag == "BigFish" && isPlayer2)
            {
                scoreKeeper2.ModifyScore(bigFishScore);
                InstantiatePrefabAsChild2.InstantiatePrefabEat();
                if(isYummy){
                    audioPlayer2.PlayYummyClip();
                    InstantiatePrefabAsChild2.InstantiatePrefabEat();
                    Debug.Log(isYummy);
                }else{
                    audioPlayer2.PlayEatingClip();
                }
                Destroy(other.gameObject);
                StartCoroutine(ResetIsEating());
            }
        }
    
        if(!isInvincible2)
        {
            if (other.tag == "Trash")
            {

                TakeDamage(damageDealer.GetDamage());
                audioPlayer2.PlayHitClip();
                damageDealer.Hit();
                StartCoroutine(ResetIsDamage());
            }
        }
    }

    // void OnTriggerEnter2D(Collider2D other)
    // {
    //     DamageDealer damageDealer = other.GetComponent<DamageDealer>();

    //     if (!isInvincible2)
    //     {
    //         if (gameObject.CompareTag("Bayi2") || gameObject.CompareTag("Remaja2"))
    //         {
    //             if (other.tag == "Fish")
    //             {
    //                 // animator2.SetBool("isEating", true);
    //                 // animator2.SetBool("isEatingRemaja", true);
    //                 if(isYummy){
    //                     audioPlayer2.PlayYummyClip();
    //                     InstantiatePrefabAsChild2.InstantiatePrefabEat();
    //                 }else{
    //                     audioPlayer2.PlayEatingClip();
    //                 }
    //                 Destroy(other.gameObject);
    //                 scoreKeeper2.ModifyScore(fishScore);
    //                 StartCoroutine(ResetIsEating());
    //             }

    //             if ((other.tag == "MediumFish" || other.tag == "BigFish") && isPlayer2)
    //             {
    //                 // animator2.SetBool("isDamage", true);
    //                 // animator2.SetBool("isDamageRemaja", true);
    //                 TakeDamage(damageDealer.GetDamage());
    //                 StartCoroutine(ResetIsDamage());
    //                 // Debug.Log("ouch");
    //             }
    //         }
    //         else if (gameObject.CompareTag("Dewasa2") || gameObject.CompareTag("DewasaMatang2"))
    //         {
    //             if (other.tag == "Fish" || other.tag == "MediumFish")
    //             {
    //                 // animator2.SetBool("isEatingDewasa", true);
    //                 // animator2.SetBool("isEatingDewasaMatang", true);
    //                 Destroy(other.gameObject);
    //                 scoreKeeper2.ModifyScore(score2);
    //                 StartCoroutine(ResetIsEating());
    //             }

    //             if (other.tag == "BigFish" && isPlayer2)
    //             {
    //                 // animator2.SetBool("isDamageDewasa", true);
    //                 // animator2.SetBool("isDamageDewasaMatang", true);
    //                 TakeDamage(damageDealer.GetDamage());
    //                 StartCoroutine(ResetIsDamage());
    //             }
    //         }
    //         else if (gameObject.CompareTag("Titanochampsa"))
    //         {
    //             if (other.tag == "Fish" || other.tag == "MediumFish" || other.tag == "BigFish")
    //             {
    //                 // animator2.SetBool("isEatingMegalodon", true);
    //                 if(isYummy){
    //                     audioPlayer2.PlayYummyClip();
    //                     InstantiatePrefabAsChild2.InstantiatePrefabEat();
    //                     Debug.Log(isYummy);
    //                 }else{
    //                     audioPlayer2.PlayEatingClip();
    //                 }
    //                 Destroy(other.gameObject);
    //                 scoreKeeper2.ModifyScore(fishScore);
    //                 StartCoroutine(ResetIsEating());
    //             }
    //         }
    
    //         if (other.tag == "Trash")
    //         {
    //             // animator2.SetBool("isDamage", true);
    //             // animator2.SetBool("isDamageRemaja", true);
    //             // animator2.SetBool("isDamageDewasa", true);
    //             // animator2.SetBool("isDamageDewasaMatang", true);
    //             // animator2.SetBool("isDamageMegalodon", true);
    //             TakeDamage(damageDealer.GetDamage());
    //             damageDealer.Hit();
    //             StartCoroutine(ResetIsDamage());
    //         }
    //     }
    // }

    public int GetHealth2()
    {
        return health2;
    }

    void TakeDamage(int damage)
    {
        health2 -= damage;
        health2 = Mathf.Max(health2, 0);
        if(health2 <= 0)
        {
            isPlayer2 = false;
            Die();
        }
    }

    void Die()
    {
        Scene scene = SceneManager.GetActiveScene();
        if(scene.name == "GameMulti"){
            levelManager.LoadGameOverMulti();
        }else{
            levelManager.LoadGameOver();
        }
        // animator2.SetBool("isDamage", false);
        // animator2.SetBool("isDamageRemaja", false);
        // animator2.SetBool("isDamageDewasa", false);
        // animator2.SetBool("isDamageDewasaMatang", false);
        // animator2.SetBool("isDamageMegalodon", false);
        // animator2.SetBool("isDead", true);
        // animator2.SetBool("isDeadRemaja", true);
        // animator2.SetBool("isDeadDewasa", true);
        // animator2.SetBool("isDeadDewasaMatang", true);
        // animator2.SetBool("isDeadMegalodon", true);
        playerMovement2.setAlive(false);
        // Destroy(gameObject); 
    }

    private IEnumerator ResetIsEating()
    {
        yield return new WaitForSeconds(delay2);
        // animator2.SetBool("isEating", false);
        // animator2.SetBool("isEatingRemaja", false);
        // animator2.SetBool("isEatingDewasa", false);
        // animator2.SetBool("isEatingDewasaMatang", false);
        // animator2.SetBool("isEatingMegalodon", false);
        foreach (Transform child in transform) {
            Destroy(child.gameObject,1);
        }
    }

    private IEnumerator ResetIsDamage()
    {
        yield return new WaitForSeconds(immuneDelay2);
        // animator2.SetBool("isDamage", false);
        // animator2.SetBool("isDamageRemaja", false);
        // animator2.SetBool("isDamageDewasa", false);
        // animator2.SetBool("isDamageDewasaMatang", false);
        // animator2.SetBool("isDamageMegalodon", false);
    }

    public bool GetPlayer()
    {
        return isPlayer2;
    }

    public void heal(int value)
    {
        health2 += value;
        if(health2 > 100)
        {
            health2 = 100;
        }
    }

    public void resetPlayer(){
        isPlayer2 = false;
    }
}
