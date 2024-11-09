using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using UnityEngine;

public class ObjectDrag : MonoBehaviour
{
    [SerializeField] GameObject initialPos;
    [SerializeField] GameObject initialPos2;
    [SerializeField] GameObject initialPos3;
    Vector3 mousePos;
    [SerializeField] GameObject dragObject;
    [SerializeField] GameObject tile;

    [SerializeField] public bool isPlaced;

    SpriteRenderer tileSprite;

    [SerializeField] BoxCollider2D boxCollider;
    [SerializeField] BoxCollider2D tileBoxCollider;

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
        initialPos = GameObject.Find("Initial Tower1 Position");
        initialPos2 = GameObject.Find("Initial Tower2 Position ");
        initialPos3 = GameObject.Find("Initial Tower3 Position ");
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
        towersManager.currentTower = dragObject;
    }

    private void OnMouseDrag()
    {
        if (goldManager.EnoughMoney(towerCost) && !isPlaced)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePos);
        }
    }

    private void OnMouseUp()
    {
        if (goldManager.EnoughMoney(towerCost) && !isPlaced)
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
                tileBoxCollider.enabled = false;
            }

            if (tile == null)
            {
                //transform.position = initialPos.transform.position;
                SetInitialPosition();
                isPlaced = false;
                boxCollider.isTrigger = false;
            }

            dragObject = null;
            towersManager.currentTower = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Tile") && gameObject.CompareTag("Tower") || gameObject.CompareTag("Tower 2") || gameObject.CompareTag("Tower 3"))
        {
            if (tile != null)
            {
                ResetTileColor();
            }
            tile = other.gameObject;
            tileBoxCollider = tile.GetComponent<BoxCollider2D>();
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
            tileBoxCollider = null;
        }
    }

    void ResetTileColor()
    {
        if (tileSprite != null)
        {
            tileSprite.color = Color.white;
            tileSprite.color = new Color(1, 1, 1, 0.0f);
        }
    }

    void ResetTile()
    {
        if (tile != tile)
        {
            ResetTileColor();
        }
    }

    void SetInitialPosition()
    {
        if (gameObject.tag == "Tower")
        {
            transform.position = initialPos.transform.position;
        }

        if (gameObject.tag == "Tower 2")
        {
            transform.position = initialPos2.transform.position;
        }

        if (gameObject.tag == "Tower 3")
        {
            transform.position = initialPos3.transform.position;
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
