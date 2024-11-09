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
        if (collision.gameObject.CompareTag("Tower"))
        {
            isAttacking = true;
            animator.SetBool("isAttacking", true); // Start Attack animation
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Tower"))
        {
            isAttacking = false;
            animator.SetBool("isAttacking", false); // Return to Walking animation
        }
    }   
}
