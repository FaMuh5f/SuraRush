using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraSlide : MonoBehaviour
{
    [SerializeField] float speed = 5f; // Speed of camera movement
    [SerializeField] bool isGame = false;

    private Vector3 startPosition; // Starting position of the camera

    // static CameraSlide instance;

    // void Awake()
    // {
    //     ManageSingleton();
    // }

    // void ManageSingleton()
    // {
    //     if (instance != null)
    //     {
    //         gameObject.SetActive(false);
    //         Destroy(gameObject);
    //     }
    //     else
    //     {
    //         instance = this;
    //         DontDestroyOnLoad(gameObject);
    //     }
    // }

    void Start()
    {
        startPosition = transform.position; // Store the starting position of the camera
        UpdateIsGame(); // Update the isGame variable
    }

    void Update()
    {
        if (isGame)
        {
            // Calculate the new position of the camera based on the current position and the speed
            float newPositionX = transform.position.x + speed * Time.deltaTime;
            Vector3 newPosition = new Vector3(newPositionX, transform.position.y, transform.position.z);

            // Update the position of the camera
            transform.position = newPosition;
        }
    }

    public void ResetCamera()
    {
        Vector3 startPosition = new Vector3(0f, 0f, -10f); // Replace with your desired start position
        transform.position = startPosition;
        UpdateIsGame(); // Update the isGame variable
    }

    void UpdateIsGame()
    {
        // Get the current active scene
        Scene currentScene = SceneManager.GetActiveScene();

        // Compare the scene name with the desired scene
        if(currentScene.name == "Game" || currentScene.name == "GameMulti")
        {
            isGame = true;
        }
    }
}
