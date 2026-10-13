using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    private int health = 50;
    private Animator animator;
    private Rigidbody2D rb;
    public int speed = 5;
    private int dir = -1;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float cliffDetectionRange = 5;
    [SerializeField] Vector3 cliffDetectionOffset;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.linearVelocityX = dir * speed;
        animator.SetFloat("Movement", dir * speed);
        if (!Physics2D.Raycast(transform.position + cliffDetectionOffset, Vector3.down, cliffDetectionRange, groundLayer))
        {
            dir = dir * -1;
            gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x * -1, 1, 1);
            cliffDetectionOffset.x = cliffDetectionOffset.x * -1;
            
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage(int dmg) {
        health = health - dmg;
        if (health <= 0)
        {
            animator.SetTrigger("Death");
        } else {
            animator.SetTrigger("Hurt");
        }
    }

    void killEnemy()
    {
        Destroy(gameObject, 2.0f);
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position + cliffDetectionOffset, transform.position + cliffDetectionOffset + new Vector3(0, -cliffDetectionRange, 0));
    }

}
