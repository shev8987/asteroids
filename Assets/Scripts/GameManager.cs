using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    [SerializeField]
    private TextMeshProUGUI scoreText;
    
    [SerializeField]
    private TextMeshProUGUI gameOverText;
    
    [SerializeField]
    private Button restartButton;
    
    [SerializeField]
    private Button launchButton;
    
    public bool isActive;

    private int _score;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void StartGame()
    {
        _score = 0;
        isActive = true;
        UpdateToScore(0);
        launchButton.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
    }
    
    public void GaveOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isActive = false;
    }

    public void RestartGame()
    {
        _score = 0;
        isActive = true;
        UpdateToScore(0);
        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
    }

    public void UpdateToScore(int scoreToAdd)
    {
        _score += scoreToAdd;
        scoreText.text = "Score: " + _score.ToString();
    }

}
