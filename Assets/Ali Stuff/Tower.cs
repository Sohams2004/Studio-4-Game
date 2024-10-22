using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
   public GameObject bulletPrefab; // Assign the bullet prefab in the Inspector
    public Transform firePoint; // The point where the bullet will be instantiated
    public float raycastRange = 10f; // The range of the raycast to detect enemies
    public float fireRate = 1f; // How often the tower shoots (1 shot per second)

    private float fireCooldown = 0f;

    void Update()
    {
        fireCooldown -= Time.deltaTime;

        // Cast a ray to the right from the tower
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, raycastRange);

        // Check if the ray hits an object with the "Enemy" tag
        if (hit.collider != null && hit.collider.CompareTag("Enemy"))
        {
            // If cooldown has expired, shoot
            if (fireCooldown <= 0f)
            {
                Shoot();
                fireCooldown = 1f / fireRate; // Reset cooldown
            }
        }
    }

    void Shoot()
    {
        // Instantiate the bullet at the fire point's position and rotation
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Optionally, add a sound or animation here for feedback
        Debug.Log("Bullet Fired!");
    }

    // Optional: Draw the ray in the editor for visualization
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.right * raycastRange);
    }
}
