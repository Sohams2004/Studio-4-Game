using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f; // Adjust the speed of the bullet
    public float lifeTime = 3f; // How long the bullet stays before being destroyed

    void Start()
    {
        // Destroy the bullet after lifeTime seconds to prevent memory issues
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        // Move the bullet to the right every frame
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with an enemy
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject); // Destroy the bullet on impact
            // Optionally: Add damage logic here, like reducing the enemy's health
        }
        else
        {
            // Optionally: Destroy the bullet if it hits any other object, like walls
            Destroy(gameObject);
        }
    }

}
