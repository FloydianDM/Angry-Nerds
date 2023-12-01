using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

namespace AngryNerds
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI healthText;
        [SerializeField] private TextMeshProUGUI gameText;
        public TextMeshProUGUI GameText => gameText;

        private GameManager _gameManager;
        private ScoreManager _scoreManager;
        private HealthManager _healthManager;

        private void Start()
        {
            _gameManager = FindObjectOfType<GameManager>();
            _scoreManager = _gameManager.GetComponent<ScoreManager>();
            _healthManager = _gameManager.GetComponent<HealthManager>();
        }

        private void Update()
        {
            DisplayScore();
            DisplayHealth();
        }

        private void DisplayScore()
        {
            if (scoreText == null)
            {
                return;
            }
            
            scoreText.text = _scoreManager.Score.ToString();
        }

        private void DisplayHealth()
        {
            if (healthText == null)
            {
                return;
            }

            healthText.text = "Shots Left: " + _healthManager.Health.ToString();
        }
    }
}

