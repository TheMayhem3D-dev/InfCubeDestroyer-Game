using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class EnemyHealth : Health
    {
        [SerializeField] private Enemy enemy;

        public override void Kill()
        {
            enemy.OnKilled();
        }
    }
}