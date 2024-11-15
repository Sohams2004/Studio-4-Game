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
    [SerializeField] float goldIncreaseUponKill;

    public SpriteRenderer enemySpriteRenderer;

    TowerStats towerStats;
    EnemyHEalthBar enemyHEalthBar;
    KillCount killCount;
    GoldManager goldManager;

    private void Start()
    {
        health = Maxhealth;
        enemyHEalthBar = GetComponent<EnemyHEalthBar>();
        enemySpriteRenderer = GetComponent<SpriteRenderer>();
        killCount = FindObjectOfType<KillCount>();
        goldManager = FindObjectOfType<GoldManager>();
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

    void GoldIncreaseOnKill()
    {
        goldManager.goldAmount += goldIncreaseUponKill;
    }

    void Death()
    {
        killCount.IncrementKills();
        GoldIncreaseOnKill();
        Destroy(gameObject);
    }


    private void Update()
    {
    }
}
