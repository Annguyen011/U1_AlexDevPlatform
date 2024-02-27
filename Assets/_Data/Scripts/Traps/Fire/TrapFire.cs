using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace U1
{
    public class TrapFire : Trap
    {
        public bool isWorking;

        private Animator animator;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        private void Start()
        {
            InvokeRepeating(nameof(FireSwitch), 0, 3);
        }

        private void Update()
        {
            animator.SetBool("isworking", isWorking);
        }

        private void FireSwitch()
        {
            isWorking = !isWorking;
        }

        protected override void OnTriggerEnter2D(Collider2D collision)
        {
            if (!isWorking) return;

            base.OnTriggerEnter2D(collision);


        }
    }
}
