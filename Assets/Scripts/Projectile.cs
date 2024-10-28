using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D projectileRB;
    [SerializeField] float force;

    EnemySpawner enemySpawner;
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
        if(other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemy Hit" + other.gameObject);
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }

    private void Update()
    {
        MoveProjectile();
    }
}
