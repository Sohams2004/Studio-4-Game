using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAtkAnim : MonoBehaviour
{
    private Animator animator;
    private bool isAttacking = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check for all three tower tags: "Tower", "Tower 2", and "Tower 3"
        if (collision.gameObject.CompareTag("Tower") || 
            collision.gameObject.CompareTag("Tower 2") || 
            collision.gameObject.CompareTag("Tower 3"))
        {
            isAttacking = true;
            animator.SetBool("isAttacking", true); // Start Attack animation
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // Check for all three tower tags on exit
        if (collision.gameObject.CompareTag("Tower") || 
            collision.gameObject.CompareTag("Tower 2") || 
            collision.gameObject.CompareTag("Tower 3"))
        {
            isAttacking = false;
            animator.SetBool("isAttacking", false); // Return to Walking animation
        }
    }
}

