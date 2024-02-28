using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace U1
{
    public class MushRoom : EnemyBase
    {
        [SerializeField] private float speed;

        protected override void Start()
        {
            base.Start();


        }

        protected override void Update()
        {
            base.Update();

            rb.velocity = new Vector2(speed * facingDirection, rb.velocity.y);
        }
    }
}
