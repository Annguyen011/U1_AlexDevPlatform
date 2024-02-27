using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace U1
{
    public class Trap : MonoBehaviour
    {
        protected virtual void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.CompareTag("Player"))
            {

            }
        }
    }
}
