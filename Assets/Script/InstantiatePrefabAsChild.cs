using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePrefabAsChild : MonoBehaviour
{
    public GameObject eatParticle; // Assign the prefab you want to instantiate here
    public GameObject speedParticler; // Assign the prefab you want to instantiate here
    public GameObject immuneParticle; // Assign the prefab you want to instantiate here
    public GameObject healParticle; // Assign the prefab you want to instantiate here
    public GameObject speedEffect; // Assign the prefab you want to instantiate here
    public GameObject immuneEffect; // Assign the prefab you want to instantiate here

    public ParticleSystemRenderer eatParticleRender;
    public ParticleSystemRenderer speedParticlerRender;
    public ParticleSystemRenderer immuneParticleRender;
    public ParticleSystemRenderer healParticleRender;

    void Awake() {
        eatParticleRender = GetComponent<ParticleSystemRenderer>();
        speedParticlerRender = GetComponent<ParticleSystemRenderer>();
        immuneParticleRender = GetComponent<ParticleSystemRenderer>();
        healParticleRender = GetComponent<ParticleSystemRenderer>();
    }

    public void InstantiatePrefabEat()
    {
        if (eatParticle != null)
        {
            // Instantiate the prefab as a child of the current GameObject (parent)
            GameObject instantiatedPrefab = Instantiate(eatParticle, transform.position, Quaternion.identity);

            // Make the parent (this GameObject) the new instantiated prefab's parent
            instantiatedPrefab.transform.SetParent(transform);
        }
        else
        {
            Debug.LogWarning("eatParticle is not assigned! Please assign a prefab to the script in the Inspector.");
        }
    }

    public void InstantiatePrefabSpeed()
    {
        if (speedParticlerRender != null)
        {
            // Instantiate the prefab as a child of the current GameObject (parent)
            GameObject instantiatedPrefab = Instantiate(speedParticler, transform.position, Quaternion.identity);

            // Make the parent (this GameObject) the new instantiated prefab's parent
            instantiatedPrefab.transform.SetParent(transform);

        }
        else
        {
            Debug.LogWarning("speedParticlerRender is not assigned! Please assign a prefab to the script in the Inspector.");
        }
    }

    public void InstantiatePrefabImmune()
    {
        if (immuneParticleRender != null)
        {
            // Instantiate the prefab as a child of the current GameObject (parent)
            GameObject instantiatedPrefab = Instantiate(immuneParticle, transform.position, Quaternion.identity);

            // Make the parent (this GameObject) the new instantiated prefab's parent
            instantiatedPrefab.transform.SetParent(transform);
        }
        else
        {
            Debug.LogWarning("immuneParticleRender is not assigned! Please assign a prefab to the script in the Inspector.");
        }
    }

    public void InstantiatePrefabHeal()
    {
        if (healParticle != null)
        {
            // Instantiate the prefab as a child of the current GameObject (parent)
            GameObject instantiatedPrefab = Instantiate(healParticle, transform.position, Quaternion.identity);

            // Make the parent (this GameObject) the new instantiated prefab's parent
            instantiatedPrefab.transform.SetParent(transform);
        }
        else
        {
            Debug.LogWarning("healParticle is not assigned! Please assign a prefab to the script in the Inspector.");
        }
    }

    public void InstantiatePrefabSpeedEffect()
    {
        if (speedEffect != null)
        {
            // Instantiate the prefab as a child of the current GameObject (parent)
            GameObject instantiatedPrefab = Instantiate(speedEffect, transform.position, Quaternion.identity);

            // Make the parent (this GameObject) the new instantiated prefab's parent
            instantiatedPrefab.transform.SetParent(transform);

            // Get the current rotation of the instantiated prefab
            Vector3 prefabRotation = instantiatedPrefab.transform.rotation.eulerAngles;

            // Set the prefab's rotation to the desired value (90 degrees on the Z-axis)
            instantiatedPrefab.transform.rotation = Quaternion.Euler(prefabRotation.x, prefabRotation.y, 90);
        }
        else
        {
            Debug.LogWarning("speedEffect is not assigned! Please assign a prefab to the script in the Inspector.");
        }
    }

    public void InstantiatePrefabImmuneEffect()
    {
        if (immuneEffect != null)
        {
            // Instantiate the prefab as a child of the current GameObject (parent)
            GameObject instantiatedPrefab = Instantiate(immuneEffect, transform.position, Quaternion.identity);

            // Make the parent (this GameObject) the new instantiated prefab's parent
            instantiatedPrefab.transform.SetParent(transform);
        }
        else
        {
            Debug.LogWarning("immuneEffect is not assigned! Please assign a prefab to the script in the Inspector.");
        }
    }


    public void movePivotPointBayi(){
        eatParticleRender.pivot = new Vector2(3.8f, -0.5f);
        speedParticlerRender.pivot = new Vector2(3.8f, -0.5f);
        immuneParticleRender.pivot = new Vector2(3.8f, -0.5f);
        healParticleRender.pivot = new Vector2(3.8f, -0.5f);
    }

    public void movePivotPointRemaja(){
        eatParticleRender.pivot = new Vector2(2.4f, -0.5f);
        speedParticlerRender.pivot = new Vector2(2.4f, -0.5f);
        immuneParticleRender.pivot = new Vector2(2.4f, -0.5f);
        healParticleRender.pivot = new Vector2(2.4f, -0.5f);
    }

    public void movePivotPointDewasa(){
        eatParticleRender.pivot = new Vector2(1.65f, 0f);
        speedParticlerRender.pivot = new Vector2(1.65f, 0f);
        immuneParticleRender.pivot = new Vector2(1.65f, 0f);
        healParticleRender.pivot = new Vector2(1.65f, 0f);
    }

    public void movePivotPointDewasaMatang(){
        eatParticleRender.pivot = new Vector2(1.25f, 0f);
        speedParticlerRender.pivot = new Vector2(1.25f, 0f);
        immuneParticleRender.pivot = new Vector2(1.25f, 0f);
        healParticleRender.pivot = new Vector2(1.25f, 0f);
    }
    
    public void movePivotPointMegalodon(){
        eatParticleRender.pivot = new Vector2(1f, 0f);
        speedParticlerRender.pivot = new Vector2(1f, 0f);
        immuneParticleRender.pivot = new Vector2(1f, 0f);
        healParticleRender.pivot = new Vector2(1f, 0f);
    }
}
