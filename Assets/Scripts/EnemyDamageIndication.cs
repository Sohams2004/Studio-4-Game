using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageIndication : MonoBehaviour
{
    [SerializeField] SpriteRenderer enemySpriteRenderer;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            enemySpriteRenderer = GetComponent<SpriteRenderer>();
            StartCoroutine(ChangeColor());
        }
    }

    IEnumerator ChangeColor()
    {
        enemySpriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        enemySpriteRenderer.color = Color.white;
    }
}
