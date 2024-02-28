using System.Collections;
using UnityEngine;

namespace U1
{
    public class RinoEnemy : EnemyBase
    {
        [SerializeField] private float speed;
        [SerializeField] private float idleTime;
        private float timerCounter;
        private bool isAggeresive;

        protected override void Update()
        {
            base.Update();


            if(isAggeresive)
            {
                return;
            }

            if(timerCounter <= 0)
            {
                rb.velocity = new Vector2(speed * facingDirection, rb.velocity.y);
            }
            else
            {
                rb.velocity = Vector2.zero;
            }

            timerCounter -= Time.deltaTime;
        }

    }
}