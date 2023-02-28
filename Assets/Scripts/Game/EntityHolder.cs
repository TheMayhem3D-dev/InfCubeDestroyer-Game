using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class EntityHolder : MonoBehaviour
    {
        [SerializeField] protected int maxEntityAmount = 5;
        protected int currentEntityAmount;
        [SerializeField] protected float reloadRate = 1f;
        protected Timer reloadRateTimer;

        protected virtual void Awake()
        {
            SetComponents();
            SetProperties();
        }

        private void SetComponents()
        {
            reloadRateTimer = new Timer(reloadRate);
        }

        protected virtual void SetProperties()
        {
            currentEntityAmount = maxEntityAmount;
        }

        protected virtual void TryReload()
        {
            if (reloadRateTimer.IsTimerStoped())
            {
                reloadRateTimer.StartTimer();
                AddEntity();
            }
        }

        protected virtual void AddEntity()
        {
            if (HolderNotFilled())
            {
                currentEntityAmount++;
            }
        }

        protected bool HolderNotFilled()
        {
            return currentEntityAmount < maxEntityAmount;
        }

        public virtual void RemoveEntity()
        {
            if (CanTakeEntity())
            {
                currentEntityAmount--;
            }
        }
        public bool CanTakeEntity()
        {
            return currentEntityAmount > 0;
        }
    }
}