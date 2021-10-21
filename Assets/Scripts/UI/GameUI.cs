using TMPro;
using UnityEngine;

namespace UI
{
    /// <summary>
    /// UI который отображается во время игры
    /// </summary>
    public class GameUI : MonoBehaviour
    {
        [SerializeField] 
        private TextMeshProUGUI scoreText;

        public TextMeshProUGUI ScoreText => scoreText;
    
        private void Start()
        {
            GameManager.Instance.EUpdateScore += UpdateScore;
        }
    
        private void UpdateScore(object sender, int score)
        {
            scoreText.text = "Score: " + score;
        }

        private void OnDisable()
        {
            GameManager.Instance.EUpdateScore -= UpdateScore;
        }
    }
}
