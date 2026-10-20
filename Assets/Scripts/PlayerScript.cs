using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerScript : MonoBehaviour
{
    private InputAction moveAction;
    private InputAction jumpAction;
    private InputAction attackAction;
    private Vector2 smoothVelocity;
    private Vector2 movementSmoothVelocity;
    private Vector2 moveValue;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    public LayerMask groundLayer;
    public Animator animator;
    private bool canMove = true;
    private int health = 50;

    [SerializeField] private Vector2 boxSize;
    [SerializeField] private float castDistance;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float smoothDampingFactor = 0.1f;
    [SerializeField] private Vector3 boxCastOffset;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
        attackAction = InputSystem.actions.FindAction("Attack");
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        moveValue = moveAction.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        animator.SetFloat("Movement", Mathf.Abs(moveValue.x));
        animator.SetFloat("yVelocity", rb.linearVelocityY);

        if (attackAction.IsPressed() && isGrounded())
        {
            animator.SetTrigger("Attack");
            canMove = false;
        }

        if (!canMove)
        {
            moveValue = Vector2.zero;
        } else
        {
            if (moveValue.x < 0)
            {
                gameObject.transform.localScale = new Vector3(-1, 1, 1);
            } else if (moveValue.x > 0)
            {
                gameObject.transform.localScale = new Vector3(1, 1, 1);
            }
        }

        smoothVelocity = Vector2.SmoothDamp(smoothVelocity, 
                                            moveValue, 
                                            ref movementSmoothVelocity, 
                                            smoothDampingFactor);
        rb.linearVelocityX = smoothVelocity.x * speed;

        if (jumpAction.IsPressed() && isGrounded() && canMove)
        {
            rb.linearVelocityY = jumpForce;
        }

    }

    private bool isGrounded()
    {
        if (Physics2D.BoxCast(transform.position + boxCastOffset, boxSize, 0, -transform.up, castDistance, groundLayer))
        {
            return true;
        } else
        {
            return false;
        }
        
    }

    public void changeCanMove()
    {
        canMove = !canMove;
    }

    public void takeDamage(int dmg)
    {
        health = health - dmg;
        Debug.Log("Took damage");
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position + boxCastOffset - transform.up * castDistance, boxSize);
    }
}
