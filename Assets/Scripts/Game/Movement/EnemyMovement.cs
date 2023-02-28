using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class EnemyMovement : LinearMovement
    {
        [SerializeField] private float rotationSpeed = 5f;
        [SerializeField] private float horizontalAreaLimit;
        [SerializeField] private float verticalAreaLimit;

        [SerializeField] private float changeTargetRateMin = 3f;
        [SerializeField] private float changeTargetRateMax = 6f;
        private float changeTargetRate;
        private Timer changeTargetTimer;

        private void Start()
        {
            TryChangeTarget();
        }

        private void Update()
        {
            changeTargetTimer.UpdateTimer();
            TryChangeTarget();
        }

        protected override void FixedUpdate()
        {
            base.FixedUpdate();
            RotateTransformSmoothly();
        }

        protected override void Move()
        {
            base.Move();
            Vector3 pos = transform.position;

            pos.x = Mathf.Clamp(pos.x, -horizontalAreaLimit, horizontalAreaLimit);
            pos.y = transform.position.y;
            pos.z = Mathf.Clamp(pos.z, -verticalAreaLimit, verticalAreaLimit);

            transform.position = pos;
        }

        protected void RotateTransformSmoothly()
        {
            if (CheckMoveDistance(targetPosition))
            {
                Quaternion lookRotation = Quaternion.LookRotation(direction, Vector3.up);
                Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed).eulerAngles;
                transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
            }
        }

        private void TryChangeTarget()
        {
            if(changeTargetTimer != null)
            {
                if (changeTargetTimer.IsTimerStoped())
                    ChangeTarget();
            }
            else
            {
                changeTargetTimer = new Timer(changeTargetRate);
                ChangeTarget();
            }
        }

        private void ChangeTarget()
        {
            changeTargetRate = Random.Range(changeTargetRateMin, changeTargetRateMax);
            changeTargetTimer.SetTimeLimit(changeTargetRate);
            changeTargetTimer.StartTimer();
            SetNextTarget();
        }

        private void SetNextTarget()
        {
            float x = Random.Range(-horizontalAreaLimit, horizontalAreaLimit);
            float z = Random.Range(-verticalAreaLimit, verticalAreaLimit);
            targetPosition = new Vector3(x, transform.position.y, z);
        }
    }
}