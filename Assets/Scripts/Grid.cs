using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField] GameObject tilePrefab;

    [SerializeField] int gridArraySize;

    [SerializeField] public int gridNodeCountX;
    [SerializeField] public int gridNodeCountY;

    [SerializeField] float nodeWidth;
    [SerializeField] float nodeHeight;

    [SerializeField] float spacingx;
    [SerializeField] float spacingy;

    [SerializeField] List<SpriteRenderer> spriteRenderers = new List<SpriteRenderer>();

    [Range(0f, 1f)]
    [SerializeField] float fadeAmount;

    [SerializeField] float startTimer;

    Grid grid;

    private void Start()
    {
        //tileInstance = tileSpriteRenderer = tilePrefab.GetComponent<SpriteRenderer>();
        grid = GetComponent<Grid>();
        GridFormation();
    }

    void GridFormation()
    {
        gridArraySize = gridNodeCountX * gridNodeCountY;

        Vector3 gameObjPos = gameObject.transform.position;

        for (int y = 0; y < gridNodeCountY; y++)
        {
            for (int x = 0; x < gridNodeCountX; x++)
            {
                int a = x + y * gridNodeCountX;

                Vector3Int gridPos = new Vector3Int(x, y, 0);
                Vector3 worldPos = new Vector3(x * (nodeWidth + spacingx), y * (nodeHeight + spacingy), 0);
                Vector3 spawnPos = gameObjPos + worldPos;


                GameObject tile = null;

                tile = Instantiate(tilePrefab, spawnPos, Quaternion.identity);
                tile.transform.localScale = new Vector3(nodeWidth, nodeHeight, 1);
                tile.transform.parent = gameObject.transform;

                var spriteRenderer = tile.GetComponent<SpriteRenderer>();
                if (spriteRenderers != null)
                {
                    spriteRenderers.Add(spriteRenderer);
                }
            }
        }
    }

    IEnumerator TileIndication()
    {
        for (int i = 0; i < spriteRenderers.Count; i++)
        {
            spriteRenderers[i].color = new Color(1, 1, 1, fadeAmount);
        }

        yield return new WaitForSeconds(1);

        if(fadeAmount > 0)
        {
            fadeAmount -= Time.deltaTime;

            for (int i = 0; i < spriteRenderers.Count; i++)
            {
                spriteRenderers[i].color = new Color(1, 1, 1, fadeAmount);
            }

            yield return null;
        }

        else
        {
            for (int i = 0; i < spriteRenderers.Count; i++)
            {
                spriteRenderers[i].color = new Color(1, 1, 1, 0);
            }
        }

        yield return new WaitForSeconds(0.5f);

        grid.enabled = false;
    }

    private void Update()
    {
        StartCoroutine(TileIndication());
    }
}
