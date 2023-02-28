using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Enemy : MonoBehaviour
    {
        private EnemyHolder enemyHolder;

        public void Init(EnemyHolder _enemyHolder)
        {
            enemyHolder = _enemyHolder;
        }

        public void OnKilled()
        {
            enemyHolder.RemoveEntity();
            Disable();
        }

        private void Disable()
        {            
            gameObject.SetActive(false);
        }
    }
}