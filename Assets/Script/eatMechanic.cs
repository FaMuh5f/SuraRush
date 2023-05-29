using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eatMechanic : MonoBehaviour
{
    [SerializeField] float destroyDelay = 0.5f;

    SpriteRenderer spriteRenderer;

    void Start() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();    
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("Ouch!");
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Fish")
        {
            Debug.Log("Ikan berhasil dimakan, poin++");
            Destroy(other.gameObject, destroyDelay);
        }

        if (other.tag == "Trash")
        {
            Debug.Log("Sampah dimakan, darah-");
            Destroy(other.gameObject, destroyDelay);
        }
    }
}
