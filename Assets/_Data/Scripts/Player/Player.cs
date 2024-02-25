using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace U1
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviour
    {
        [Header("Movement")]
        public float moveSpeed;

        private Rigidbody2D rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
    }
}
