using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game 
{
    public class ParabolaMovement : MonoBehaviour
    {
        [SerializeField] protected float speed;
        [SerializeField] protected float arcHeight;

        private Vector3 startPosition;
        private Vector3 targetPosition;

        private float stepScale;
        private float progress;

        private bool canMove;

        void Start()
        {
            SetUpProperties();
        }

        private void SetUpProperties()
        {
            startPosition = transform.position;
            float distance = Vector3.Distance(startPosition, targetPosition);
            stepScale = speed / distance;
        }

        public void SetPoints(Vector3 startPoint, Vector3 endPoint)
        {
            startPosition = startPoint;
            targetPosition = endPoint;
        }

        public void StartMovement()
        {
            canMove = true;
        }

        private void StopMovement()
        {
            canMove = false;
        }

        public void ResetMovement()
        {
            StopMovement();
            progress = 0f;
        }

        private void Update()
        {
            ProcessMovement();
        }

        private void ProcessMovement()
        {
            if (canMove)
            {
                progress = Mathf.Min(progress + Time.deltaTime * stepScale, 1.0f);
                float parabola = 1.0f - 4.0f * (progress - 0.5f) * (progress - 0.5f);
                Vector3 nextPos = Vector3.Lerp(startPosition, targetPosition, progress);
                nextPos.y += parabola * arcHeight;

                transform.LookAt(nextPos, transform.forward);
                transform.position = nextPos;
            }

            if (progress == 1.0f)
                Arrived();
        }

        protected virtual void Arrived()
        {

        }
    }
}