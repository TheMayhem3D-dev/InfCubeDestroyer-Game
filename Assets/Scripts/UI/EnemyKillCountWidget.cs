using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Core;
using TMPro;

namespace UI
{
    public class EnemyKillCountWidget : EventEntity
    {
        [SerializeField] private TextMeshPro text;
        private int currentKilCount = 0;

        public override void Subscribe()
        {
            if (GameEvents.main != null)
            {
                GameEvents.main.onEnemyKillCountChanged += UpdateEnemiesKillCount;
            }
            else
                throw new MissingReferenceException();
        }

        public override void Unsubscribe()
        {
            if (GameEvents.main != null)
            {
                GameEvents.main.onEnemyKillCountChanged -= UpdateEnemiesKillCount;
            }
        }

        private void UpdateEnemiesKillCount(int value)
        {
            currentKilCount += value;
            text.SetText(currentKilCount.ToString());
        }
    }
}