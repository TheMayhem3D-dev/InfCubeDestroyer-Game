using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class GameEvents : Singleton<GameEvents>
    {
        public delegate void EventHandler();
        public delegate void EventHandler<X>(X value);

        #region Events

        public event EventHandler<int> onAmmoCountStarted;
        public event EventHandler<int> onAmmoCountChanged;

        public event EventHandler<float> onReloadTimerChanged;
        public event EventHandler<int> onEnemyKillCountChanged;

        #endregion

        #region InitEvents

        void InitEventHandler() { }

        void InitEventHandler<X>(X value) { }

        protected override void Awake()
        {
            Init();
            base.Awake();
        }

        private void Init()
        {
            onAmmoCountStarted = new EventHandler<int>(InitEventHandler<int>);
            onAmmoCountChanged = new EventHandler<int>(InitEventHandler<int>);
            onReloadTimerChanged = new EventHandler<float>(InitEventHandler<float>);
            onEnemyKillCountChanged = new EventHandler<int>(InitEventHandler<int>);
        }

        #endregion

        #region NotifyOnEvent
        public void NotifyOnAmmoCountStarted(int value) => onAmmoCountStarted.Invoke(value);
        public void NotifyOnAmmoCountChanged(int value) => onAmmoCountChanged.Invoke(value);
        public void NotifyOnReloadTimerChanged(float value) => onReloadTimerChanged.Invoke(value);
        public void NotifyOnEnemyKillCountChanged(int value) => onEnemyKillCountChanged.Invoke(value);

        #endregion
    }
}
