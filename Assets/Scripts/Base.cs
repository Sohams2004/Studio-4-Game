using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField] public bool isGameOver;

    GameManager manager;

    private void Start()
    {
        manager = FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            isGameOver = true;
            manager.GameOver();
        }
    }
}
