using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace U1
{
    public class TrapFire : Trap
    {
        public bool isWorking;
        public bool hasSwitcher;

        private Animator animator;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        private void Start()
        {
            if(!hasSwitcher)
                InvokeRepeating(nameof(FireSwitch), 0, 3);
        }

        private void Update()
        {
            animator.SetBool("isworking", isWorking);
        }

        public void FireSwitch()
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
