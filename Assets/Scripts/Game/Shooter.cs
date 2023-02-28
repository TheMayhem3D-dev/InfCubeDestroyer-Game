using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
using System;

namespace Game
{
    [RequireComponent(typeof(BulletHolder))]
    public class Shooter : MonoBehaviour
    {
        [SerializeField] private LayerMask groundLayer;
        [SerializeField] private Transform bulletSpawnPoint;
        private const string bulletTag = "Bullet";

        private BulletHolder bulletMagazine;

        [Header("Shoot Properties")]
        [SerializeField] private float fireRate = 0.5f;
        private Timer fireRateTimer;

        private void Awake()
        {
            SetComponents();
        }

        private void SetComponents()
        {
            bulletMagazine = GetComponent<BulletHolder>();
            fireRateTimer = new Timer(fireRate);
        }

        private void Update()
        {
            fireRateTimer.UpdateTimer();
        }

        public void Fire()
        {
            if (fireRateTimer.IsTimerStoped())
            {
                if (bulletMagazine.CanShoot())
                {
                    if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit raycastHit, Mathf.Infinity, groundLayer))
                    {
                        fireRateTimer.StartTimer();
                        bulletMagazine.RemoveBullet();
                        SpawnBullet(raycastHit.point);
                    }
                }
            }
        }

        private void SpawnBullet(Vector3 endPoint)
        {
            GameObject bulletGo = ObjectPooler.SpawnFromPool(bulletTag, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            Bullet bullet = bulletGo.GetComponent<Bullet>();

            if (bullet != null)
            {
                bullet.SetUpMovement(endPoint);
                bullet.Release();
            }
            else
                throw new MissingComponentException();
        }
    }
}