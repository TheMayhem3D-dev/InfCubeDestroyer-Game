using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

namespace Game
{
    public class BulletMagazine : MonoBehaviour
    {
        [SerializeField] private int maxBulletAmount = 5;
        private int currentBulletAmount;
        [SerializeField] private float reloadRate = 1f;
        private Timer reloadRateTimer;

        private void Awake()
        {
            SetComponents();
            SetProperties();
        }

        private void Start()
        {
            GameEvents.main.NotifyOnAmmoCountStarted(maxBulletAmount);
        }

        private void SetComponents()
        {
            reloadRateTimer = new Timer(reloadRate);
        }

        private void SetProperties()
        {
            currentBulletAmount = maxBulletAmount;
        }

        private void Update()
        {
            if (MagazineNotFilled())
            {
                reloadRateTimer.UpdateTimer();
                GameEvents.main.NotifyOnReloadTimerChanged(reloadRateTimer.TimeRemaining);
                TryReload();
            }
        }

        private void TryReload()
        {
            if (reloadRateTimer.IsTimerStoped())
            {
                reloadRateTimer.StartTimer();
                AddBullet();
            }
        }

        public void AddBullet()
        {
            if (MagazineNotFilled())
            {
                currentBulletAmount++;
                UpdateAmmoCount();
            }
        }

        private bool MagazineNotFilled()
        {
            return currentBulletAmount < maxBulletAmount;
        }

        public void RemoveBullet()
        {
            if (CanShoot())
            {
                currentBulletAmount--;
                UpdateAmmoCount();
            }
        }

        public void UpdateAmmoCount()
        {
            GameEvents.main.NotifyOnAmmoCountChanged(currentBulletAmount);
        }

        public bool CanShoot()
        {
            return currentBulletAmount > 0;
        }
    }
}