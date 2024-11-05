using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameObject bulletPrefab; 
    public Transform firePoint; 
    public float raycastRange = 10f; 
    public float fireRate = 1f; 

    private float fireCooldown = 0f;

    void Update()
    {
        fireCooldown -= Time.deltaTime;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, raycastRange);

        if (hit.collider != null && hit.collider.CompareTag("Enemy"))
        {
            if (fireCooldown <= 0f)
            {
                Shoot();
                fireCooldown = 1f / fireRate; 
            }
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.right * raycastRange);
    }
}
