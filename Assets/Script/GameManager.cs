using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    ScoreKeeper scoreKeeper;
    ScoreKeeper2 scoreKeeper2;
    CameraSlide cameraSlide;
    Spawner spawner;

    public Transform cameraTransform;

    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        scoreKeeper2 = FindObjectOfType<ScoreKeeper2>();
        cameraSlide = FindObjectOfType<CameraSlide>();
        spawner = FindObjectOfType<Spawner>();
    }

    void Start()
    {
        // Vector3 startPosition = new Vector3(0f, 0f, -10f); // Replace with your desired start position
        // Vector3 newPosition = startPosition + new Vector3(0f, 0f, -10f);
        // transform.position = startPosition;
        cameraSlide.ResetCamera();
        spawner.ResetSpawner();
        scoreKeeper.ResetScore();
        scoreKeeper2.ResetScore2();
        // ResetCameraPosition();
        // cameraSlide.setGame(true);
    }

    void Update() 
    {
        
    }

    public void ResetCameraPosition()
    {
        cameraTransform.position = new Vector3(0f, 0f, -10f);
    }
}
