using System;
using System.Collections;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace UI
{
    /// <summary>
    /// UI который отображается во время игры
    /// </summary>
    public class GameUI : MonoBehaviour
    {
        [SerializeField] 
        private TextMeshProUGUI scoreText;

        [SerializeField] 
        private TextMeshProUGUI laserText;

        [SerializeField] 
        private GameObject laserIcon;
        
        private void Awake()
        {
            GameManager.Instance.EUpdateScore += UpdateScore;
            GameManager.Instance.EUpdateTime += InstanceOnEUpdateTime;
        }

        private void InstanceOnEUpdateTime(object sender, float e)
        {
            StartCoroutine(ReloadCoroutine(e));
        }

        private void UpdateScore(object sender, int score)
        {
            scoreText.text = "Score: " + score;
        }

        private IEnumerator ReloadCoroutine(float reloadingTime)
        {
            laserText.gameObject.SetActive(true);
            laserIcon.SetActive(false);
            
            do
            {
                if (reloadingTime <= 0.5f)
                {
                    laserText.gameObject.SetActive(false);
                    laserIcon.SetActive(true);
                    break;
                }

                laserText.text = Mathf.RoundToInt(reloadingTime).ToString();
                reloadingTime -= Time.deltaTime;
                yield return null;
            } 
            while (reloadingTime > 0);

        }
        
    }
}
