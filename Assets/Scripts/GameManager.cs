using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject gameOverPanel;

    Base _base;

    private void Start()
    {
        _base = FindObjectOfType<Base>();
        gameOverPanel.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void GameOver()
    {
        if (_base.isGameOver)
        {
            Time.timeScale = 0f;
            gameOverPanel.SetActive(true);
        }
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
}
