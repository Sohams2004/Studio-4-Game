using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject pausePanel;

    [SerializeField] int pauseIndex;

    Base _base;

    private void Start()
    {
        _base = FindObjectOfType<Base>();
        gameOverPanel.SetActive(false);
        pausePanel.SetActive(false);
        Time.timeScale = 1.0f;
        Screen.SetResolution(1920, 1080, true);
    }

    public void GameOver()
    {
        if (_base.isGameOver)
        {
            Time.timeScale = 0f;
            gameOverPanel.SetActive(true);
        }
    }

    void PauseScreen()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseIndex++;
            Time.timeScale = 0;
            pausePanel.SetActive(true);
        }

        /*if(Input.GetKeyDown(KeyCode.Escape) && pauseIndex == 2)
        {
            pauseIndex = 1;
            Time.timeScale = 1;
            pausePanel.SetActive(false);
        }*/
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    public void Restart()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void Update()
    {
        PauseScreen();
    }
}
