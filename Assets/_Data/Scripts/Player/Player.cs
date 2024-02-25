using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace U1
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] private float moveSpeed;
        [SerializeField] private float jumpForce;
        private float movingInput;

        private Rigidbody2D rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            movingInput = Input.GetAxisRaw("Horizontal");

            rb.velocity = new Vector2(moveSpeed * movingInput, rb.velocity.y);

            if(Input.GetButton("Jump"))
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }
    }
}
