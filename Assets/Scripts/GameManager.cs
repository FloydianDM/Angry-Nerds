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

        private void ManageSingleton()
        {
            if (_instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                _instance = this;
            }
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(0);
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
                RestartGame();    
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

