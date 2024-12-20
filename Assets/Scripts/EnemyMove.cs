using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Rigidbody2D enemyRB;

    [SerializeField] float enemySpeed;


    private void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
    }

    void MoveEnemy()
    {
        enemyRB.velocity = Vector2.left * enemySpeed * 0.2f;
        Debug.Log(enemyRB.velocity);
    }

    private void Update()
    {
        MoveEnemy();
    }
}
