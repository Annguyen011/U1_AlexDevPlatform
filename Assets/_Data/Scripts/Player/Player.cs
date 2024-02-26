using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace U1
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviour
    {
        #region Abilities
        [Header("# Movement")]
        [SerializeField] private Vector2 wallJumpDirection;
        [SerializeField] private float moveSpeed;
        [SerializeField] private float jumpForce;
        private float movingInput;
        private bool canDoubleJump;

        [Header("# Ground detected")]
        [SerializeField] private LayerMask whatIsGround;
        [SerializeField] private float groundCheckDistance;
        [SerializeField] private float wallCheckDistance;
        private bool isWalleDetected;
        private bool isGrounded;
        private bool canallSlide;
        private bool isallSliding;
        private bool facingRight = true;
        private int facingDirection = 1;

        [Header("# Key blinds")]
        [SerializeField] private KeyCode jumpKey = KeyCode.Space;

        [Header("# Animation name")]
        [SerializeField] private string movingAnmt;
        [SerializeField] private string slideAnmt;
        [SerializeField] private string groundedAnmt;
        [SerializeField] private string yVelocityAnmt;

        private Rigidbody2D rb;
        private Animator animator;
        #endregion

        #region Unity methods
        private void Awake()
        {
            animator = GetComponent<Animator>();
            rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            AnimationCtrl();
            FlipController();

            CollectionCheck();
            InputChecks();

            Move();
        }

        #endregion

        private void AnimationCtrl()
        {
            animator.SetBool(movingAnmt, movingInput != 0);
            animator.SetBool(groundedAnmt, isGrounded);
            animator.SetBool(slideAnmt, isallSliding);

            animator.SetFloat(yVelocityAnmt, rb.velocity.y);
        }

        private void InputChecks()
        {
            movingInput = Input.GetAxisRaw("Horizontal");

            if(Input.GetKeyDown(KeyCode.S))
            {
                canallSlide = false;
            }

            if (Input.GetKeyDown(jumpKey))
            {
                JumpButton();
            }
        }
        #region Moving
        private void JumpButton()
        {
            if(isWalleDetected)
            { 
                WallJump();
            }
            else if (isGrounded)
            {
                Jump();
            }
            else if (canDoubleJump)
            {
                canDoubleJump = false;
                Jump();
            }

            canallSlide = false;
        }
        private void Move()
        {
            rb.velocity = new Vector2(moveSpeed * movingInput, rb.velocity.y);
        }

        private void Jump()
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        private void WallJump()
        {
            rb.velocity = new Vector2(wallJumpDirection.x * -facingDirection, wallJumpDirection.y);
        }
        #endregion

        #region Flip
        private void FlipController()
        {
            if (facingRight && rb.velocity.x < 0)
            {
                Flip();
            }
            else if (!facingRight && rb.velocity.x > 0)
            {
                Flip();
            }
        }

        private void Flip()
        {
            facingRight = !facingRight;
            facingDirection *= -1;

            transform.Rotate(0, 180, 0);
        }
        #endregion

        private void CollectionCheck()
        {
            isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, whatIsGround);
            isWalleDetected = Physics2D.Raycast(transform.position, Vector2.right * facingDirection, wallCheckDistance, whatIsGround);

            if (isGrounded)
            {
                canDoubleJump = true;
            }

            if (!isWalleDetected)
            {
                isallSliding = false;
                canallSlide = false;
            }

            if (isWalleDetected && rb.velocity.y < 0)
            {
                canallSlide = true;
            }

            if (canallSlide)
            {
                isallSliding = true;

                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * .1f);
            }

        }



        private void OnDrawGizmos()
        {
            Gizmos.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y - groundCheckDistance));
            Gizmos.DrawLine(transform.position, new Vector2(transform.position.x + wallCheckDistance * facingDirection, transform.position.y));
        }
    }
}
