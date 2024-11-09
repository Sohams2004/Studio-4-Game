using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowersManager : MonoBehaviour
{
    [SerializeField] GameObject tower;
    [SerializeField] GameObject tower2;
    [SerializeField] GameObject tower3;
    [SerializeField] public GameObject currentTower;

    Vector2 towerPos;
    Vector2 towerPos2;
    Vector2 towerPos3;

    public void SpawnTowers()
    {
        if (currentTower.tag == "Tower")
        {
            GameObject _tower1 = Instantiate(tower, towerPos, Quaternion.identity);
            tower.transform.localScale = Vector2.one;
        }

        if (currentTower.tag == "Tower 2")
        {
            GameObject _tower2 = Instantiate(tower2, towerPos, Quaternion.identity);
            tower2.transform.localScale = Vector2.one;
        }

        if (currentTower.tag == "Tower 3")
        {
            GameObject _tower3 = Instantiate(tower3, towerPos, Quaternion.identity);
            tower3.transform.localScale = Vector2.one;
        }
    }

    public void UpdateTowerPos(Vector2 Position)
    {
        towerPos = Position;
        Debug.Log(Position);
    }
}
