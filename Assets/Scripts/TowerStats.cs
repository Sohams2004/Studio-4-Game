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
    ObjectDrag objectDrag;

    private void Start()
    {
        health = Maxhealth;
        towerHealthBar = GetComponent<TowerHealthBar>();
        objectDrag = GetComponent<ObjectDrag>();
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
        objectDrag.tileBoxCollider.enabled = true;
        Destroy(gameObject);
    }
}
