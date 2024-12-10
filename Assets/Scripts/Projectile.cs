using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D projectileRB;
    [SerializeField] float force;
    SpriteRenderer enemySpriteRenderer;

    EnemySpawner enemySpawner;
    TowerStats towerStats;
    EnemyStats enemyStats;
    private void Start()
    {
        projectileRB = GetComponent<Rigidbody2D>();
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }

    void MoveProjectile()
    {
        projectileRB.velocity = Vector2.right * force;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Tower") || other.gameObject.CompareTag("Tower 2") || other.gameObject.CompareTag("Tower 3"))
        {
            Debug.Log("Tower Detected");
            towerStats = other.GetComponent<TowerStats>();
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemy Hit" + other.gameObject);
            enemyStats = other.GetComponent<EnemyStats>();
            enemyStats.DecrementHealth(towerStats.damage);
            Destroy(gameObject);
            //Destroy(other.gameObject);
        }
    }



    private void Update()
    {
        MoveProjectile();
    }
}
