using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

namespace Game
{
    public class Shooter : MonoBehaviour
    {
        [SerializeField] private Transform bulletSpawnPoint;
        private const string bulletTag = "Bullet";

        public void Fire()
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit raycastHit))
            {
                GameObject bulletGo = ObjectPooler.SpawnFromPool(bulletTag, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
                Bullet bullet = bulletGo.GetComponent<Bullet>();

                if (bullet != null)
                {
                    bullet.SetUpMovement(raycastHit.point);
                    bullet.Release();
                }
                else
                    throw new MissingComponentException();
            }
        }
    }
}