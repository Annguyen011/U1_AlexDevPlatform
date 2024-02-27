using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace U1
{
    public class TrapFireSwitcher : MonoBehaviour
    {
        [SerializeField] private TrapFire myTrap;

        private Animator animator;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.CompareTag("Player"))
            {
                animator.SetTrigger("Pressed");
                myTrap.FireSwitch();
            }
        }
    }
}
