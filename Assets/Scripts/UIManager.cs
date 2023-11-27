using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace AngryNerds
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        private ScoreManager _scoreManager;

        // Start is called before the first frame update
        private void Start()
        {
            _scoreManager = FindObjectOfType<ScoreManager>();
        }

        // Update is called once per frame
        private void Update()
        {
            DisplayScore();
        }

        private void DisplayScore()
        {
            scoreText.text = _scoreManager.Score.ToString();
        }
    }
}

