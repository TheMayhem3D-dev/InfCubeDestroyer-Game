using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public abstract class EventEntity : MonoBehaviour
    {
        protected virtual void Awake() => Subscribe();
        protected virtual void OnDestroy() => Unsubscribe();

        public abstract void Subscribe();
        public abstract void Unsubscribe();
    }
}