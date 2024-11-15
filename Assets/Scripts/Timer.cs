using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] int min;
    [SerializeField] float second;

    [SerializeField] TextMeshPro timerText;

    void StartTimer()
    {
        second -= Time.deltaTime;
        float time = Mathf.Round(second);
        timerText.text = time.ToString();

        if (second <= 0)
        {
            Time.timeScale = 0f;
        }
    }

    private void Update()
    {
        StartTimer();
    }
}
