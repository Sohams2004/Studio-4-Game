using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] EnemyType enemyType;

    [SerializeField] public float Maxhealth;
    public float health;
    [SerializeField] float damage;
    [SerializeField] float timer;
    float time;

    public SpriteRenderer enemySpriteRenderer;

    TowerStats towerStats;
    EnemyHEalthBar enemyHEalthBar;

    private void Start()
    {
        health = Maxhealth;
        enemyHEalthBar = GetComponent<EnemyHEalthBar>();
        enemySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        towerStats = other.gameObject.GetComponent<TowerStats>();

        if (other.gameObject.CompareTag("Tower") || other.gameObject.CompareTag("Tower 2") || other.gameObject.CompareTag("Tower 3"))
        {
            towerStats.DecrementHealth(damage * Time.deltaTime);
        }
    }

    public void DecrementHealth(float damage)
    {
        health -= damage;
        if(health <= 0 )
        {
            Death();
        }

        enemyHEalthBar.ReduceHealthBar();
    }

    void Death()
    {
        Destroy(gameObject);
    }


    private void Update()
    {
    }
}
