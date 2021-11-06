using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Basics
{
    public class CameraFollow : MonoBehaviour
    {
        public Transform playerTransform;
        public float followSpeed = 10;

        public Vector2 max;
        public Vector2 min;
        public Vector2 offset;
        private Vector2 smoothedPosition;
        public bool isSleeping = false;

        void Start()
        {
            ResetFollow();
        }
        void FixedUpdate()
        {
            if (playerTransform != null && !isSleeping)
            {
                float clampedX = Mathf.Clamp(playerTransform.position.x, min.x, max.x);
                float clampedY = Mathf.Clamp(playerTransform.position.y, min.y, max.y);
                Vector2 targetPosition = new Vector2(clampedX, clampedY) + offset;
                smoothedPosition = Vector2.Lerp(transform.position, targetPosition, followSpeed * Time.fixedDeltaTime);
            }
        }
        private void LateUpdate()
        {
            transform.position = smoothedPosition;
        }

        public void ResetFollow()
        {
                playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }
}