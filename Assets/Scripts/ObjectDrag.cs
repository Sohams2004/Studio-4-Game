using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using TMPro;
using UnityEngine;

public class ObjectDrag : MonoBehaviour
{
    [SerializeField] GameObject initialPos;
    [SerializeField] GameObject initialPos2;
    [SerializeField] GameObject initialPos3;
    Vector3 mousePos;
    GameObject dragObject;
    GameObject tile;

    public bool isPlaced;

    SpriteRenderer tileSprite;

    BoxCollider2D boxCollider;
    public BoxCollider2D tileBoxCollider;
    BoxCollider2D towerBoxCollider;

    ObjectDrag objectDrag;
    TowersManager towersManager;
    GoldManager goldManager;

    [SerializeField] float towerCost;

    [SerializeField] TextMeshPro costText;

    SpriteRenderer towerSpriteRenderer;

    private void Start()
    {
        objectDrag = GetComponent<ObjectDrag>();
        towersManager = FindObjectOfType<TowersManager>();
        goldManager = FindObjectOfType<GoldManager>();
        costText = GetComponentInChildren<TextMeshPro>();

        towerSpriteRenderer = GetComponent<SpriteRenderer>();
        towerBoxCollider = GetComponent<BoxCollider2D>();
        initialPos = GameObject.Find("Initial Tower1 Position");
        initialPos2 = GameObject.Find("Initial Tower2 Position ");
        initialPos3 = GameObject.Find("Initial Tower3 Position ");

        CostText();
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
        DisableCostText();
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
                costText.enabled = true;
            }

            dragObject = null;
            towersManager.currentTower = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Tile") /*&& (gameObject.CompareTag("Tower") || gameObject.CompareTag("Tower 2") || gameObject.CompareTag("Tower 3")*/)
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

    void DisableCostText()
    {
        costText.enabled = false;
    }

    void CostText()
    {
        costText.text = towerCost.ToString();
    }

    private void Update()
    {
        if (!goldManager.EnoughMoney(towerCost))
        {
            towerSpriteRenderer.color = new Color(1, 1, 1, 0.3f);
            towerBoxCollider.enabled = false;
        }

        else
        {
            towerSpriteRenderer.color = new Color(1, 1, 1, 1);
            towerBoxCollider.enabled = true;
        }
    }
}
