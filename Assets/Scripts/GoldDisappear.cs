using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GoldDisappear : MonoBehaviour
{
    float timer;
    float fadeDuration;
    SpriteRenderer goldSprite;

    private void Start()
    {
        goldSprite = GetComponent<SpriteRenderer>();
    }

    void DestroyGold()
    {
        timer += Time.deltaTime;

        if (timer > 5)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        DestroyGold();
    }
}
