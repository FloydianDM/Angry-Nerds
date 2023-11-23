using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

namespace AngryNerds
{
    public class ThrowHandler : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D pivot;
        [SerializeField] private GameObject characterPrefab;
        [SerializeField] private float detachTime;
        [SerializeField] private float respawnTime;

        private Camera _mainCamera;
        private Rigidbody2D _currentCharacterRb;
        private SpringJoint2D _currentCharacterSpringJoint;
        private bool _isDragging;

        private void OnEnable()
        {
            EnhancedTouchSupport.Enable();
        }

        private void OnDisable()
        {
            EnhancedTouchSupport.Disable();
        }

        private void Start()
        {
            _mainCamera = Camera.main;
            SpawnCharacter();
        }

         private void Update()
        {
            if (_currentCharacterRb == null) 
            {
                return;
            }

            if (Touch.activeTouches.Count == 0)
            {
                if (_isDragging)
                {
                    StartCoroutine(ThrowCharacter());
                }

                _isDragging = false;
                
                return;
            }

            AdjustThrowPosition();
        }

        
        private void SpawnCharacter()
        {
            GameObject instance = Instantiate(characterPrefab, pivot.position, Quaternion.identity);
            _currentCharacterRb = instance.GetComponent<Rigidbody2D>();
            _currentCharacterSpringJoint = instance.GetComponent<SpringJoint2D>();
            _currentCharacterSpringJoint.connectedBody = pivot;
        }

        private void AdjustThrowPosition()
        {
            _isDragging = true;

            Vector2 characterPosition =  new();

            foreach (Touch touch in Touch.activeTouches)
            {
                characterPosition += touch.screenPosition; 
            }

            characterPosition /= Touch.activeTouches.Count;
            Vector3 worldPosition = _mainCamera.ScreenToWorldPoint(characterPosition);

            _currentCharacterRb.position = worldPosition;
            _currentCharacterRb.isKinematic = true;
        }

        private IEnumerator ThrowCharacter()
        {
            _currentCharacterRb.isKinematic = false;
            _currentCharacterRb = null;

            yield return new WaitForSeconds(detachTime);
            DetachCharacter();

            yield return new WaitForSeconds(respawnTime);
            SpawnCharacter();
        }

        private void DetachCharacter()
        {
            _currentCharacterSpringJoint.enabled = false;
            _currentCharacterSpringJoint.connectedBody = null;
        }
    }

}

