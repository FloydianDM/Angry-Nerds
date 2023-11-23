using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace AngryNerds
{
    public class CharacterColliderHandler : MonoBehaviour
    {
        private float _vanishTime = 2f;

        private void OnCollisionEnter2D(Collision2D other) 
        {
            if (!other.gameObject.CompareTag("Construction"))
            {
                return;
            }

            Destroy(gameObject, _vanishTime);    
        }
    }
}


