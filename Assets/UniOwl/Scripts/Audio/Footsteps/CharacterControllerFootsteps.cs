﻿using UnityEngine;

namespace UniOwl.Audio
{
    public class CharacterControllerFootsteps : MonoBehaviour
    {
        private const float RAY_DISTANCE = .25f;
        
        [SerializeField] private FootstepsData footstepsData;

        [SerializeField] private LayerMask groundMask;
        [SerializeField] private Transform pivot;
        
        [SerializeField] private CharacterController characterController;
        [SerializeField] private float minDistance;

        private Vector3 oldPosition;
        private float error;

        private void Start()
        {
            oldPosition = characterController.transform.position;
        }

        private void Update()
        {
            Vector3 newPosition = characterController.transform.position;

            if (characterController.isGrounded)
            {
                float distance = Vector3.Distance(newPosition, oldPosition);
                error += distance;
            }

            oldPosition = newPosition;

            if (error >= minDistance)
            {
                error -= minDistance;

                if (!Physics.Raycast(pivot.position, -pivot.up, out RaycastHit hit, RAY_DISTANCE, groundMask)) return;
                
                var cue = footstepsData.GetCue(hit.collider.material);
                AudioSFXSystem.PlayCue(cue, hit.point);
            }
        }
    }
}