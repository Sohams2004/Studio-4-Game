using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHEalthBar : MonoBehaviour
{
    [SerializeField] GameObject healthBar;
    float originalScale;

    EnemyStats enemyStats;

    float ReduceHealthPercent()
    {
        Debug.Log(enemyStats.Maxhealth);
        Debug.Log(enemyStats.health);

        return (enemyStats.Maxhealth - enemyStats.health) / enemyStats.Maxhealth;
    }

    private void Start()
    {
        enemyStats = GetComponent<EnemyStats>();
        originalScale = healthBar.transform.localScale.x;
    }

    public void ReduceHealthBar()
    {
        float reduceHealthPrcnt = ReduceHealthPercent();
        float bla = originalScale * reduceHealthPrcnt;
        Debug.Log(bla);
        Debug.Log(ReduceHealthPercent());
        healthBar.transform.localScale = new Vector2(originalScale - bla, 0.05f);
    }
}
