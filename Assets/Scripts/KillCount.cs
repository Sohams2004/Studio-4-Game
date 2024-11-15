using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEngine;

public class KillCount : MonoBehaviour
{
    [SerializeField] public int killCount;

    [SerializeField] TextMeshPro killCounttext;

    public void IncrementKills()
    {
        killCount++;
        killCounttext.text = killCount.ToString();
    }
}
