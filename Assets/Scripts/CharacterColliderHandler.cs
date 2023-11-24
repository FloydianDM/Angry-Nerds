using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace AngryNerds
{
    public class CharacterColliderHandler : MonoBehaviour
    {
        private GameManager _gameManager;
        private ScoreManager _scoreManager;
        private HealthManager _healthManager;
        private float _vanishTime = 2f;

        private void Start()
        {
            _gameManager = FindObjectOfType<GameManager>();
            _healthManager = _gameManager.GetComponent<HealthManager>();
            _scoreManager = _gameManager.GetComponent<ScoreManager>();
        }

        private void OnCollisionEnter2D(Collision2D other) 
        {
            if (other.gameObject.CompareTag("Construction"))
            {
                _healthManager.ReduceHealth();
                 Destroy(gameObject, _vanishTime);   
            }
            
            if (other.gameObject.CompareTag("Enemy"))
            {
                _scoreManager.AddScore(10);
                Destroy(gameObject, _vanishTime);
            }
        }
    }
}


