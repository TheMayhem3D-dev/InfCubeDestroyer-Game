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
            ObjectPooler.SpawnFromPool(bulletTag, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        }
    }
}