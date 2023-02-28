using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(BulletMovement))]
    public class Bullet : MonoBehaviour
    {
        private BulletMovement movement;

        private void Awake()
        {
            SetComponents();
        }

        private void SetComponents()
        {
            movement = GetComponent<BulletMovement>();
            movement.SetBullet(this);
        }

        public void SetUpMovement(Vector3 endPoint)
        {
            movement.SetPoints(transform.position, endPoint);
        }

        public void Release()
        {
            movement.StartMovement();
        }


        public void OnDisable()
        {
            ResetBullet();
        }

        public void ResetBullet()
        {
            movement.ResetMovement();
        }

        public void Disable()
        {
            gameObject.SetActive(false);
        }
    }
}