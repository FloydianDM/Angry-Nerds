using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

namespace AngryNerds
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager _instance;

        private ScoreManager _scoreManager;
        private HealthManager _healthManager;

        private void Awake()
        {
            ManageSingleton();
        }

        private void Start()
        {
            _scoreManager = GetComponent<ScoreManager>();
            _healthManager = GetComponent<HealthManager>();
        }

        private void ManageSingleton()
        {
            if (_instance != null)
            {
                gameObject.SetActive(false);
                Destroy(gameObject);
            }
            else
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }

        public void SetMenuScreen()
        {
            SceneManager.LoadScene("Start");
            _scoreManager.ResetScore();
            _healthManager.ResetHealth();
        }

        public void StartGame()
        {
            SceneManager.LoadScene(1);
        }

        public void SetWinScene(bool isWin)
        {
            if (isWin)
            {
                SceneManager.LoadScene("Win");
            }
            else
            {
                SceneManager.LoadScene("Lose");
            }

            _scoreManager.ResetScore();
            _healthManager.ResetHealth();
        }

        public void LoadNextLevel()
        {
            if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings - 3)
            {
                SetWinScene(true);
            }
 
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
             
            SceneManager.LoadScene(nextSceneIndex);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}

