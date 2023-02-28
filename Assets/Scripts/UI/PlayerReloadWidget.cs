using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Core;

namespace UI
{
    public class PlayerReloadWidget : EventEntity
    {
        [SerializeField] private Text reloadTimerText;

        public override void Subscribe()
        {
            if (GameEvents.main != null)
            {
                GameEvents.main.onReloadTimerChanged += UpdateReloadTimerText;
            }
            else
                throw new MissingReferenceException();
        }

        public override void Unsubscribe()
        {
            if (GameEvents.main != null)
            {
                GameEvents.main.onReloadTimerChanged -= UpdateReloadTimerText;
            }
        }

        public void UpdateReloadTimerText(float value)
        {
            reloadTimerText.text = value.ToString("0.00");
        }
    }
}