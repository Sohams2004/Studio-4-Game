using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField] GameObject nodePrefab;

    [SerializeField] int gridArraySize;

    [SerializeField] public int gridNodeCountX;
    [SerializeField] public int gridNodeCountY;

    [SerializeField] int nodeWidth;
    [SerializeField] int nodeHeight;

    private void Start()
    {
        gridArraySize = gridNodeCountX * gridNodeCountY;

        Vector3 gameObjPos = gameObject.transform.position;

        for (int y = 0; y < gridNodeCountY; y++)
        {
            for (int x = 0; x < gridNodeCountX; x++)
            {
                int a = x + y * gridNodeCountX;

                Vector3Int gridPos = new Vector3Int(x, y, 0);
                Vector3 worldPos = new Vector3(x * nodeWidth, y * nodeHeight, 0);
                Vector3 spawnPos = gameObjPos + worldPos;


                GameObject tile = null;

                tile = Instantiate(nodePrefab, spawnPos, Quaternion.identity);
                tile.transform.localScale = new Vector3(nodeWidth, nodeHeight, 1);
                tile.transform.parent = gameObject.transform;
            }
        }
    }
}
