using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(LinearInterpolation))]
    public class Bullet : MonoBehaviour
    {
        private LinearInterpolation movement;

        private void Awake()
        {
            SetComponents();
        }

        private void SetComponents()
        {
            movement = GetComponent<LinearInterpolation>();
            movement.SetInterpolatedObject(gameObject);
        }

        public void SetUpMovement(Vector3 endPoint)
        {
            movement.SetPoints(transform.position, endPoint);
        }

        public void Release()
        {
            movement.StartInterpolate();
        }


        public void OnDisable()
        {
            Reset();
        }

        public void Reset()
        {
            movement.StopInterpolate();
        }
    }
}