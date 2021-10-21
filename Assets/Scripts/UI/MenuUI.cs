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
        
        [SerializeField] private GameUI gameUI;
    
        private void Start()
        {
            GameManager.Instance.EUpdateScore += UpdateScore;
            GameManager.Instance.EGameOver += OnGameOver;
            StartGame();
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
            GameManager.Instance.ResetScore();
            gameUI.gameObject.SetActive(true);
            scoreText.gameObject.SetActive(false);
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
            GameManager.Instance.ResetScore();
            
            gameUI.gameObject.SetActive(true);
            scoreText.gameObject.SetActive(false);
            gameOverText.gameObject.SetActive(false);
            restartButton.gameObject.SetActive(false);
        }
    }
}
