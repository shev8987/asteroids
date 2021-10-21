using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class MenuUI : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI scoreText;
    
        [SerializeField]
        private TextMeshProUGUI gameOverText;
    
        [SerializeField]
        private Button restartButton;
    
        [SerializeField]
        private Button launchButton;

        [SerializeField] private GameUI gameUI;
    
        private void Start()
        {
            GameManager.Instance.EUpdateScore += UpdateScore;
            GameManager.Instance.EGameOver += OnGameOver;
        }
    
        /// <summary>
        /// Обновление очков
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="score"></param>
        private void UpdateScore(object sender, int score)
        {
            scoreText.text = "Score: " + score;
        }
    
        /// <summary>
        ///  Обработка конца игры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void OnGameOver(object sender, EventArgs eventArgs)
        {
            SetActivateDeactivateGameOver();
        }

        /// <summary>
        /// Запуск игры
        /// </summary>
        public void StartGame()
        {
            scoreText.text = "Score: " + 0;
            GameManager.Instance.OnEUpdateScore(0);
        
            gameUI.gameObject.SetActive(true);
            scoreText.gameObject.SetActive(false);
            launchButton.gameObject.SetActive(false);
            restartButton.gameObject.SetActive(false);
        }
    
        /// <summary>
        ///  Включение выключение компонентов UI в время проигрыша
        /// </summary>
        private void SetActivateDeactivateGameOver()
        {
            gameUI.gameObject.SetActive(false);
            scoreText.gameObject.SetActive(true);
            gameOverText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
        }

        /// <summary>
        /// Метод перезапуска игры
        /// </summary>
        public void RestartGame()
        {
            gameUI.ScoreText.text = "Score: " + 0;
            gameUI.gameObject.SetActive(true);
            scoreText.gameObject.SetActive(false);
            scoreText.text = "Score: " + 0;
            GameManager.Instance.OnEUpdateScore(0);
            gameOverText.gameObject.SetActive(false);
            restartButton.gameObject.SetActive(false);
        }

    
        private void OnDisable()
        {
            GameManager.Instance.EUpdateScore -= UpdateScore;
            GameManager.Instance.EGameOver -= OnGameOver;
        }
    }
}
