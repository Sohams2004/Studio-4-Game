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
   [SerializeField] private List<Transform> spawnPoints = new List<Transform>();
    [SerializeField] private GameObject mushroomEnemy;
    [SerializeField] private GameObject fireEnemy;
    [SerializeField] private GameObject iceEnemy;

    [SerializeField] private float initialSpawnTime = 4f; // Start with a spawn rate of 4 seconds
    private float currentSpawnTime;
    private float timer = 120f; // Starts at 120 and counts down

    private void Start()
    {
        currentSpawnTime = initialSpawnTime;
    }

    private void SpawnEnemy(GameObject enemyType)
    {
        int randomPosition = Random.Range(0, spawnPoints.Count);
        Transform spawnLocation = spawnPoints[randomPosition];
        Instantiate(enemyType, spawnLocation.position, Quaternion.identity);
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0) return; // Stop spawning when timer reaches zero

        // Countdown to the next spawn
        currentSpawnTime -= Time.deltaTime;
        if (currentSpawnTime <= 0)
        {
            if (timer > 100) // First 20 seconds: only mushrooms
            {
                SpawnEnemy(mushroomEnemy);
                currentSpawnTime = initialSpawnTime;
            }
            else if (timer > 70) // From 20 to 50 seconds: mushrooms and fire enemies
            {
                GameObject enemyToSpawn = (Random.value > 0.5f) ? mushroomEnemy : fireEnemy;
                SpawnEnemy(enemyToSpawn);
                currentSpawnTime = initialSpawnTime;
            }
            else // After 50 seconds: spawn all enemies at a faster rate
            {
                int enemyType = Random.Range(0, 3);
                GameObject enemyToSpawn = (enemyType == 0) ? mushroomEnemy : (enemyType == 1) ? fireEnemy : iceEnemy;
                SpawnEnemy(enemyToSpawn);
                currentSpawnTime = 1f; // Faster spawn rate after 50 seconds
            }
        }
    }
}
