using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using TMPro;
using UnityEngine;

public class GoldManager : MonoBehaviour
{
    [SerializeField] float goldAmount;
    [SerializeField] float goldMaxAmount;
    [SerializeField] float goldIncreaseRate;
    [SerializeField] TextMeshPro goldText;

    private void Start()
    {
        goldAmount = 0;
    }

    void GoldGenerate()
    {
        goldAmount += Time.deltaTime * goldIncreaseRate;

        if (goldAmount > goldMaxAmount)
        {
            goldAmount = goldMaxAmount;
        }
        
        float gold = Mathf.Round(goldAmount);
        goldText.text = gold.ToString();
    }

    private void Update()
    {
        GoldGenerate();
    }
}
