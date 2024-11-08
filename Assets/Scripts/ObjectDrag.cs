using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using UnityEngine;

public class ObjectDrag : MonoBehaviour
{
    [SerializeField] Vector2 initialPos;
    Vector3 mousePos;
    [SerializeField] GameObject dragObject;
    [SerializeField] GameObject tile;

    [SerializeField] public bool isPlaced;

    SpriteRenderer tileSprite;

    [SerializeField] BoxCollider2D boxCollider;

    [SerializeField] ObjectDrag objectDrag;
    [SerializeField] TowersManager towersManager;
    [SerializeField] GoldManager goldManager;

    [SerializeField] float towerCost;

    SpriteRenderer towerSpriteRenderer;

    private void Start()
    {
        objectDrag = GetComponent<ObjectDrag>();
        towersManager = FindObjectOfType<TowersManager>();
        goldManager = FindObjectOfType<GoldManager>();

        towerSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    Vector3 GetMousePos()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    private void OnMouseDown()
    {
        mousePos = Input.mousePosition - GetMousePos();
        dragObject = gameObject;
        boxCollider = dragObject.GetComponent<BoxCollider2D>();
        boxCollider.isTrigger = true;
        towersManager.UpdateTowerPos(gameObject.transform.position);
    }

    private void OnMouseDrag()
    {
        if (goldManager.EnoughMoney(towerCost))
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePos);
        }
    }

    private void OnMouseUp()
    {
        if (goldManager.EnoughMoney(towerCost))
        {
            if (tile != null)
            {
                dragObject.transform.position = tile.transform.position;
                isPlaced = true;
                ResetTileColor();
                objectDrag.enabled = false;
                boxCollider.isTrigger = false;
                towersManager.SpawnTowers();
                goldManager.DecrementGold(towerCost);
            }

            if (tile == null)
            {
                transform.position = initialPos;
                isPlaced = false;
                boxCollider.isTrigger = false;
            }

            dragObject = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Tile") && gameObject.CompareTag("Player"))
        {
            if (tile != null)
            {
                ResetTileColor();
            }
            tile = other.gameObject;
            tileSprite = tile.GetComponent<SpriteRenderer>();
            tileSprite.color = Color.red;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == tile && !isPlaced)
        {
            ResetTileColor();
            tile = null;
        }
    }

    void ResetTileColor()
    {
        if (tileSprite != null)
        {
            tileSprite.color = Color.white;
            tileSprite.color = new Color(1, 1, 1, 0.4f);
        }
    }

    void ResetTile()
    {
        if (tile != tile)
        {
            ResetTileColor();
        }
    }

    private void Update()
    {
        if (!goldManager.EnoughMoney(towerCost))
        {
            towerSpriteRenderer.color = new Color(1, 1, 1, 0.3f);
        }

        else
        {
            towerSpriteRenderer.color = new Color(1, 1, 1, 1);
        }
    }
}
