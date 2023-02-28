using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(Rigidbody))]
    public class LinearMovement : MonoBehaviour
    {
        protected Rigidbody rb;
        [SerializeField] protected float maxMovementSpeed = 15f;

        protected Vector3 targetPosition;

        protected Vector3 direction = Vector3.zero;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        protected virtual void FixedUpdate()
        {
            Move();
        }

        protected virtual void Move()
        {
            if (CheckMoveDistance(targetPosition))
            {
                direction = targetPosition - transform.position;
                direction = direction.normalized * Time.deltaTime * maxMovementSpeed;
                rb.MovePosition(transform.position + direction);
            }
        }

        protected bool CheckMoveDistance(Vector3 target)
        {
            return Vector3.Distance(transform.position, target) > 0.2;
        }
    }
}
