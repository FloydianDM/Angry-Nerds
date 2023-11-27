using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

namespace AngryNerds
{
    public class ScoreManager : MonoBehaviour
    {
        public int Score {get; private set;}
        
        private GameManager _gameManager;

        private void Start()
        {
            _gameManager = FindObjectOfType<GameManager>();
        }

        public void AddScore(int addedScore)
        {
            Score += addedScore;
        }
    }
}


