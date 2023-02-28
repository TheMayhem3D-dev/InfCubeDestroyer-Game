using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class BulletMovement : ParabolaMovement
    {
        private Bullet bullet;

        public void SetBullet(Bullet _bullet)
        {
            bullet = _bullet;
    }

        protected override void Arrived()
        {
            bullet.Disable();
        }
    }
}