using System;
using System.Collections;
using System.Collections.Generic;
using AngryNerds;
using UnityEngine;

namespace AngryNerds
{
    public class HealthManager : MonoBehaviour
    {
        private GameManager _gameManager;
        private int _health = 5;
        public int Health => _health;
        private int _initialHealth;

        private void Start()
        {
            _initialHealth = _health; // use it for reset game
            _gameManager = FindObjectOfType<GameManager>();
        }

        public void ResetHealth()
        {
            _health = _initialHealth;
        }

        public void ReduceHealth()
        {
            if (_health == 0)
            {
                HandleDeath();

                return;
            }

            _health --;

        }

        private void HandleDeath()
        {
            _gameManager.RestartLevel();
            ResetHealth();
        }

    }    
}

