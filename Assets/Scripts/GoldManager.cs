using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using TMPro;
using UnityEngine;

public class GoldManager : MonoBehaviour
{
    [SerializeField] public float goldAmount;
    [SerializeField] float goldMaxAmount;
    [SerializeField] float goldIncreaseRate;
    [SerializeField] TextMeshPro goldText;


    public bool EnoughMoney(float towerCost)
    {
        if(goldAmount >= towerCost)
        {
            return true;
        }

        return false;
    }

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

    public void DecrementGold(float gold)
    {
        goldAmount -= gold;
    }

    private void Update()
    {
        GoldGenerate();
    }
}
