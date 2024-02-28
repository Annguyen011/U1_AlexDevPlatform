using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace U1
{
    public class EnemyBase : MonoBehaviour
    {
        protected Animator animator;
        protected Rigidbody2D rb;

        [Header("# Ground detected")]
        [SerializeField] protected LayerMask whatIsGround;
        [SerializeField] protected float groundCheckDistance;
        [SerializeField] protected float wallCheckDistance;
        protected bool isWalleDetected;
        protected bool isGrounded;
        protected int facingDirection = 1;

        protected virtual void Start()
        {
            animator = GetComponent<Animator>();
            rb = GetComponent<Rigidbody2D>();
        }

        protected virtual void Update()
        {
            CollectionCheck();

            if(isWalleDetected)
            {
                Flip();
            }
        }

        public virtual void Damage()
        {
            Destroy(gameObject);
        }

        protected virtual void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                collision.gameObject.GetComponent<Player>().KnockBack();
            }
        }

        protected virtual void Flip()
        {
            facingDirection *= -1;

            transform.Rotate(0, 180, 0);
        }

        protected virtual void CollectionCheck()
        {
            isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, whatIsGround);
            isWalleDetected = Physics2D.Raycast(transform.position, Vector2.right * facingDirection, wallCheckDistance, whatIsGround);
        }

        protected virtual void OnDrawGizmos()
        {
            Gizmos.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y - groundCheckDistance));
            Gizmos.DrawLine(transform.position, new Vector2(transform.position.x + wallCheckDistance * facingDirection, transform.position.y));
        }
    }
}
