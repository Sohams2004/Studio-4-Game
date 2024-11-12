using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerStats : MonoBehaviour
{
    [SerializeField] TowerType towerType;

    [SerializeField] public float Maxhealth;
    public float health;
    [SerializeField] public float damage;

    TowerHealthBar towerHealthBar;

    private void Start()
    {
        health = Maxhealth;
        towerHealthBar = GetComponent<TowerHealthBar>();
    }
    public void DecrementHealth(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Death();
        }

        towerHealthBar.ReduceHealthBar();
    }

    public void Death()
    {
        Destroy(gameObject);
    }
}
