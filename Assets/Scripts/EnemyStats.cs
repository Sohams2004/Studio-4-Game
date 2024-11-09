using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] public float Maxhealth;
    public float health;
    [SerializeField] float damage;

    TowerStats towerStats;
    EnemyHEalthBar enemyHEalthBar;

    private void Start()
    {
        health = Maxhealth;
        enemyHEalthBar = GetComponent<EnemyHEalthBar>();
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        towerStats = other.gameObject.GetComponent<TowerStats>();

        if (other.gameObject.CompareTag("Tower"))
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
}
