using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowersManager : MonoBehaviour
{
    [SerializeField] GameObject tower;

    Vector2 towerPos;

    public void SpawnTowers()
    {
        GameObject tower1 = Instantiate(tower, towerPos, Quaternion.identity);
        tower1.transform.localScale = Vector2.one;
        Debug.Log(tower.transform.localScale);
    }

    public void UpdateTowerPos(Vector2 Position)
    {
        towerPos = Position;
    }
}
