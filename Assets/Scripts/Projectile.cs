using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D projectileRB;
    [SerializeField] float force;

    private void Start()
    {
        projectileRB = GetComponent<Rigidbody2D>();
    }

    void MoveProjectile()
    {
        projectileRB.velocity = Vector2.right * force;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemy Hit");
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        MoveProjectile();
    }
}
