using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float sceneLoadDelay = 2f;
    ScoreKeeper scoreKeeper;
    CameraSlide cameraSlide;

    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        cameraSlide = FindObjectOfType<CameraSlide>();
    }

    public void LoadGame()
    {
        // scoreKeeper.ResetScore();
        // cameraSlide.ResetCamera();
        // cameraSlide.setGame(true);
        SceneManager.LoadScene("Game");
    }

    public void LoadSingelMulti()
    {
        // scoreKeeper.ResetScore();
        // cameraSlide.ResetCamera();
        // cameraSlide.setGame(true);
        SceneManager.LoadScene("SingelMulti");
    }

    public void LoadGameMulti()
    {
        // scoreKeeper.ResetScore();
        // cameraSlide.ResetCamera();
        // cameraSlide.setGame(true);
        SceneManager.LoadScene("GameMulti");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadEnsiklo()
    {
        SceneManager.LoadScene("Ensiklopedia");
    }

    public void LoadHelp()
    {
        SceneManager.LoadScene("Help");
    }

    public void LoadSetting()
    {
        SceneManager.LoadScene("Setting");
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad("GameOver", sceneLoadDelay));
    }

    public void LoadGameOverMulti()
    {
        StartCoroutine(WaitAndLoad("GameOverMulti", sceneLoadDelay));
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }

    IEnumerator WaitAndLoad(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
