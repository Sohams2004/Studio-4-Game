using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] float rayLength;
    [SerializeField] float spawnInterval;
    [SerializeField] float lastSpawnTime;
    [SerializeField] float spawnOffset;

    [SerializeField] LayerMask enemyLayer;

    ObjectDrag objectDrag;
    [SerializeField] GameObject projectile;


    private void Start()
    {
        objectDrag = GetComponent<ObjectDrag>();
    }

    void EnemyDetect()
    {
        if (objectDrag.isPlaced)
        {
            bool isRay = Physics2D.Raycast(transform.position, Vector2.right, rayLength, enemyLayer);
            if (isRay)
            {
                Debug.Log("Enemy detected");
                StartShooting();
            }
        }
    }

    void StartShooting()
    {
        lastSpawnTime += Time.deltaTime;

        if (lastSpawnTime >= spawnInterval)
        {
            //Vector3 spawnPosition = transform.position + new Vector3(spawnOffset, 0, 0);
            GameObject projectileSpawn = Instantiate(projectile, transform.position , Quaternion.identity);
            lastSpawnTime = 0;
        }
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
