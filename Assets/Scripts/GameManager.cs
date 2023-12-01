using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AngryNerds
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager _instance;

        private void Awake()
        {
            ManageSingleton();
        }

        private void Start()
        {
            StartMenuScreen();
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

        public void StartMenuScreen()
        {
            SceneManager.LoadScene(0);
        }

        public void StartGame()
        {
            SceneManager.LoadScene(1);
        }
        
        public void RestartLevel()
        {
            Scene activeScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(activeScene.buildIndex);
        }

        public void LoadNextLevel()
        {
            if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCount - 1)
            {
                StartMenuScreen();
                
                return;    
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

