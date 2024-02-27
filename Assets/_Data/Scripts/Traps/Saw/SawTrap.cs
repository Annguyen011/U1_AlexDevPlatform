using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace U1
{
    public class SawTrap : Trap
    {
        [SerializeField] private bool isWorking;
        [SerializeField] private float speed;
        [SerializeField] private Transform[] movePoints;

        private int indexPoint = 0;
        private bool direction;

        //private Animator animator;

        private void Awake()
        {
            //animator = GetComponent<Animator>();
        }

        private void Start()
        {
            transform.position = movePoints[indexPoint].position;
        }

        private void Update()
        {
            //animator.SetBool("isWorking", isWorking);

            if (Vector2.Distance(transform.position, movePoints[indexPoint].position) <= .2f)
            {
                if (direction)
                {
                    indexPoint++;
                }
                else
                {
                    indexPoint--;
                }

                if (indexPoint >= movePoints.Length - 1)
                {
                    indexPoint = movePoints.Length - 1;
                    direction = false;
                }
                else if (indexPoint <= 0)
                {
                    indexPoint = 0;
                    direction = true;
                }

            }
            transform.position = Vector3.MoveTowards(transform.position, movePoints[indexPoint].position, speed * Time.deltaTime);
        }
    }
}
