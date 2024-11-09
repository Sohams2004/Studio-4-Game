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

    private Animator weaponAnimator; // Reference to the Animator on Bow, IceWeapon, or FireWeapon
    private bool canShoot;

    private void Start()
    {
        objectDrag = GetComponent<ObjectDrag>();

        // Attempt to find an Animator on Bow, IceWeapon, or FireWeapon child objects
        Transform bow = transform.Find("Bow");
        Transform iceWeapon = transform.Find("IceWeapon");
        Transform fireWeapon = transform.Find("FireWeapon");

        if (bow != null)
            weaponAnimator = bow.GetComponent<Animator>();
        else if (iceWeapon != null)
            weaponAnimator = iceWeapon.GetComponent<Animator>();
        else if (fireWeapon != null)
            weaponAnimator = fireWeapon.GetComponent<Animator>();

        canShoot = true; // Enable shooting at start
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
            else if (weaponAnimator != null)
            {
                weaponAnimator.SetBool("IsShooting", false); // Return to idle if no enemy is detected
            }
        }
    }

    void StartShooting()
    {
        lastSpawnTime += Time.deltaTime;
        if (lastSpawnTime >= spawnInterval)
        {
            Debug.Log("Projectile shot");
            if (weaponAnimator != null)
            {
                weaponAnimator.SetBool("IsShooting", true); // Trigger shooting animation
            }
            Instantiate(projectile, transform.position, Quaternion.identity); // Spawn projectile

            lastSpawnTime = 0;
            canShoot = false; // Temporarily disable shooting
            StartCoroutine(ResetShootFlag()); // Re-enable shooting after interval
        }
    }

    private IEnumerator ResetShootFlag()
    {
        yield return new WaitForSeconds(spawnInterval);
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
