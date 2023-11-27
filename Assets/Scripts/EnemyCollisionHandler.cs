using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AngryNerds
{
    public class EnemyCollisionHandler : MonoBehaviour
    {
        private float _vanishTime = 1f;
        private ScoreManager _scoreManager;
        private bool _isScoreAdded;
        private ParticleSystem _enemyHitVFX;

        private void Start() 
        {
            _scoreManager = FindObjectOfType<ScoreManager>();
            _enemyHitVFX = gameObject.GetComponentInChildren<ParticleSystem>();
        }
        
        private void OnCollisionEnter2D(Collision2D other) 
        {
            if (other.gameObject.CompareTag("Surface") || other.gameObject.CompareTag("Player"))
            {
                _enemyHitVFX.Play();
                
                if (!_isScoreAdded)
                {
                    _scoreManager.AddScore(10);
                    _isScoreAdded = true;
                    Destroy(gameObject, _vanishTime);
                }
            }
        }
    }
}


