using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    ScoreKeeper scoreKeeper;
    CameraSlide cameraSlide;
    Spawner spawner;

    public Transform cameraTransform;

    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        cameraSlide = FindObjectOfType<CameraSlide>();
        spawner = FindObjectOfType<Spawner>();
    }

    void Start()
    {
        cameraSlide.ResetCamera();
        spawner.ResetSpawner();
        scoreKeeper.ResetScore();
        // ResetCameraPosition();
    }

    void Update() 
    {
        cameraSlide.setGame(true);    
    }

    public void ResetCameraPosition()
    {
        cameraTransform.position = new Vector3(0f, 0f, -10f);
    }
}
