using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] float rayLength;
    [SerializeField] float spawnInterval;
    private float lastSpawnTime;

    [SerializeField] LayerMask enemyLayer;

    ObjectDrag objectDrag;
    [SerializeField] GameObject projectile;

    private Animator bowAnimator; // Animator on the bow child object
    private bool canShoot; // Flag to control shooting timing

    private void Start()
    {
        objectDrag = GetComponent<ObjectDrag>();
        bowAnimator = transform.Find("Bow").GetComponent<Animator>(); // Locate bow Animator
        canShoot = true; // Allow shooting at the start
    }

    void EnemyDetect()
    {
        if (objectDrag.isPlaced)
        {
            bool isRay = Physics2D.Raycast(transform.position, Vector2.right, rayLength, enemyLayer);
            if (isRay && canShoot)
            {
                StartShooting();
            }
            else
            {
                bowAnimator.SetBool("IsShooting", false); // Return to idle if no enemy is detected
            }
        }
    }

    void StartShooting()
    {
        lastSpawnTime += Time.deltaTime;
        if (lastSpawnTime >= spawnInterval)
        {
            Debug.Log("Bullet shot");
            bowAnimator.SetBool("IsShooting", true); // Set animation to shooting
            GameObject _projectile = Instantiate(projectile, transform.position, Quaternion.identity); // Instantiate projectile
            _projectile.transform.parent = gameObject.transform;

            lastSpawnTime = 0;
            canShoot = false; // Disable shooting temporarily
            StartCoroutine(ResetShootFlag()); // Start coroutine to re-enable shooting
        }
    }

    private IEnumerator ResetShootFlag()
    {
        yield return new WaitForSeconds(spawnInterval); // Wait for spawn interval
        canShoot = true; // Re-enable shooting
    }

    private void Update()
    {
        EnemyDetect();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, Vector2.right * rayLength);
    }
}
