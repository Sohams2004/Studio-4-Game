using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SocialPlatforms.Impl;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<Transform> spawnPoints = new List<Transform>();
    [SerializeField] List<GameObject> enemies = new List<GameObject>();

    [SerializeField] int enemyCount = 0;
    [SerializeField] int lastSpawnIndex;

    [SerializeField] float startEnemySpawnTime;

    private void Start()
    {
    }

    public void SpawnEnemy()
    {
        int randomPosition = Random.Range(0, spawnPoints.Count);
        int randomEnemy = Random.Range(0, enemies.Count);
        while (true)
        {
            if (randomPosition == lastSpawnIndex)
            {
                randomPosition = Random.Range(0, spawnPoints.Count);
            }

            else
            {
                lastSpawnIndex = randomPosition;
                break;
            }
        }
        Transform spawnLocation = spawnPoints[randomPosition];
        GameObject spawnEnemy = Instantiate(enemies[randomEnemy], spawnLocation.position, Quaternion.identity);
    }

    private void Update()
    {
        startEnemySpawnTime -= Time.deltaTime;

        if (startEnemySpawnTime < 0)
        {
            SpawnEnemy();
            startEnemySpawnTime = 4;
        }
    }
}
