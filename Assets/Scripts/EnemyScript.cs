using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    private int health = 50;
    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
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
        }
    }

    void killEnemy()
    {
        Destroy(gameObject, 2.0f);
    }

}
