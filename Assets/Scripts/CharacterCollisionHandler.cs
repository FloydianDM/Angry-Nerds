using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AngryNerds
{
    public class CharacterCollisionHandler : MonoBehaviour
    {
        private GameManager _gameManager;
        private HealthManager _healthManager;
        private ParticleSystem _nerdHitVFX;
        private float _vanishTime = 2f;
        private bool _isTouched = false;

        private void Start()
        {
            _gameManager = FindObjectOfType<GameManager>();
            _healthManager = _gameManager.GetComponent<HealthManager>();
            _nerdHitVFX = gameObject.GetComponentInChildren<ParticleSystem>();
        }

        private void Update()
        {
            CheckEnemyCount();
        }

        private void CheckEnemyCount()
        {
            GameObject[] _enemies = GameObject.FindGameObjectsWithTag("Enemy");

            if (_enemies.Length == 0)
            {
                _gameManager.LoadNextLevel();
            }
        }

        private void OnCollisionEnter2D(Collision2D other) 
        {
            if (!_isTouched)
            {
                if (other.gameObject.CompareTag("Construction") || other.gameObject.CompareTag("Surface"))
                {
                    if (other.gameObject.CompareTag("Construction"))
                    {
                        other.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                    }
                    
                    _isTouched = true;
                    _nerdHitVFX.Play();
                    _healthManager.ReduceHealth();
                    Destroy(gameObject, _vanishTime);   
                }
            }
            
        }
    }
}


