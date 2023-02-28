using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

namespace Game
{
    public class EnemyHolder : EntityHolder
    {
        private const string enemyTag = "Enemy";

        [SerializeField] private float reloadRateMin = 1f;
        [SerializeField] private float reloadRateMax = 3f;

        protected override void SetProperties()
        {
            
        }

        private void Start()
        {
            currentEntityAmount = 0;
            for (int i = 0; i < maxEntityAmount; i++)
            {
                AddEntity();
            }
        }

        private void Update()
        {
            if (HolderNotFilled())
            {
                reloadRateTimer.UpdateTimer();
                TryReload();
            }
        }

        protected override void TryReload()
        {
            if (reloadRateTimer.IsTimerStoped())
            {
                reloadRate = Random.Range(reloadRateMin, reloadRateMax);
                reloadRateTimer.SetTimeLimit(reloadRate);
                reloadRateTimer.StartTimer();
                if (HolderNotFilled())
                    AddEntity();
            }
        }

        protected override void AddEntity()
        {
            if (HolderNotFilled())
            {
                GameObject enemyGo = ObjectPooler.SpawnFromPool(enemyTag, transform.position, transform.rotation);
                Enemy enemy = enemyGo.GetComponent<Enemy>();

                if (enemy != null)
                {
                    enemy.Init(this);
                }
                else
                    throw new MissingComponentException();
            }
            base.AddEntity(); 
        }

        public override void RemoveEntity()
        {
            base.RemoveEntity();
            UpdateEnemyKillCountUI();
        }

        private void UpdateEnemyKillCountUI()
        {
            GameEvents.main.NotifyOnEnemyKillCountChanged(1);
        }
    }
}