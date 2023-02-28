using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

namespace Game
{
    public class BulletHolder : EntityHolder
    {
        private void Start()
        {
            GameEvents.main.NotifyOnAmmoCountStarted(maxEntityAmount);
        }

        private void Update()
        {
            if (HolderNotFilled())
            {
                reloadRateTimer.UpdateTimer();
                GameEvents.main.NotifyOnReloadTimerChanged(reloadRateTimer.TimeRemaining);
                TryReload();
            }
        }

        protected override void AddEntity()
        {
            base.AddEntity();
            UpdateAmmoCountUI();
        }

        public override void RemoveEntity()
        {
            base.RemoveEntity();
            UpdateAmmoCountUI();
        }

        public void UpdateAmmoCountUI()
        {
            GameEvents.main.NotifyOnAmmoCountChanged(currentEntityAmount);
        }
    }
}