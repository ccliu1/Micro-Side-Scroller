using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerScript : MonoBehaviour
{
    private InputAction moveAction;
    private InputAction jumpAction;
    private Vector2 smoothVelocity;
    private Vector2 movementSmoothVelocity;
    private Vector2 moveValue;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    public LayerMask groundLayer;
    public Animator animator;
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
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        moveValue = moveAction.ReadValue<Vector2>();
        Debug.Log("moveValue: " + moveValue.x);
    }

    void FixedUpdate()
    {
        // RaycastHit2D ground = Physics2D.Raycast(transform.position, -Vector2.up);
        if (moveValue.x < 0)
        {
            spriteRenderer.flipX = true;
        } else if (moveValue.x > 0)
        {
            spriteRenderer.flipX = false;
        }

        animator.SetFloat("Movement", Mathf.Abs(moveValue.x));

        smoothVelocity = Vector2.SmoothDamp(smoothVelocity, 
                                            moveValue, 
                                            ref movementSmoothVelocity, 
                                            smoothDampingFactor);
        rb.linearVelocityX = smoothVelocity.x * speed;

        if (jumpAction.IsPressed() && isGrounded())
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

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position + boxCastOffset - transform.up * castDistance, boxSize);
    }
}
