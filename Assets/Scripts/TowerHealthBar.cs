using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHealthBar : MonoBehaviour
{
    [SerializeField] GameObject healthBar;
    float originalScale;

    TowerStats towerStats;

    float ReduceHealthPercent()
    {
        Debug.Log(towerStats.Maxhealth);
        Debug.Log(towerStats.health);

        return (towerStats.Maxhealth - towerStats.health) / towerStats.Maxhealth;
    }

    private void Start()
    {
        towerStats = GetComponent<TowerStats>();
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
