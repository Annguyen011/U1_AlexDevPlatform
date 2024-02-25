using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace U1
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviour
    {
        #region Abilities
        [Header("Movement")]
        [SerializeField] private float moveSpeed;
        [SerializeField] private float jumpForce;
        private float movingInput;
        private bool canDoubleJump;

        [Header("Ground detected")]
        [SerializeField] private LayerMask whatIsGround;
        [SerializeField] private float groundCheckDistance;
        private bool isGrounded;

        [Header("Key blinds")]
        [SerializeField] private KeyCode jumpKey = KeyCode.Space;

        private Rigidbody2D rb;
        #endregion

        #region Unity methods
        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            CollectionCheck();
            InputChecks();

            Move();
        }

        private void InputChecks()
        {
            movingInput = Input.GetAxisRaw("Horizontal");

            if (Input.GetKey(jumpKey))
            {
                JumpButton();
            }
        }

        private void JumpButton()
        {
            if (isGrounded)
            {
                Jump();
            }
            else if (canDoubleJump)
            {
                canDoubleJump = false;
                Jump();
            }
        }
        #endregion
        private void Move()
        {
            rb.velocity = new Vector2(moveSpeed * movingInput, rb.velocity.y);
        }

        private void CollectionCheck()
        {
            isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, whatIsGround);

            if (isGrounded)
            {
                canDoubleJump = true;
            }
        }

        private void Jump()
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y - groundCheckDistance));
        }
    }
}
