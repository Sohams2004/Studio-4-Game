using System.Collections;
using System.Collections.Generic;
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
    //BoxCollider2D tileCollider;

    //[SerializeField] TileStatus tileStatus;
    [SerializeField] ObjectDrag objectDrag;
    private void Start()
    {
        objectDrag = GetComponent<ObjectDrag>();
    }

    Vector3 GetMousePos()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    private void OnMouseDown()
    {
        mousePos = Input.mousePosition - GetMousePos();
        dragObject = gameObject;
    }

    private void OnMouseDrag()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePos);
    }

    private void OnMouseUp()
    {
        if (tile != null)
        {
            dragObject.transform.position = tile.transform.position;
            isPlaced = true;
            //tileStatus.isUsed = true;
            ResetTileColor();
            objectDrag.enabled = false;
            //DisableTile();
        }

        if (tile == null)
        {
            transform.position = initialPos;
            isPlaced = false;
            //tileStatus = null;
        }

        dragObject = null;
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
            //tileStatus = tile.GetComponent<TileStatus>();
            tileSprite.color = Color.red;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == tile && !isPlaced)
        {
            //tileStatus.isUsed = false;
            ResetTileColor();
            //EnableTile();
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

    /*void DisableTile()
    {
        if (tileStatus.isUsed)
        {
            tileCollider = tile.GetComponent<BoxCollider2D>();
            tileCollider.enabled = false;
        }
    }*/

    /*void EnableTile()
    {
        if (!tileStatus.isUsed)
        {
            tileCollider.enabled = true;
        }
    }*/

    private void Update()
    {
    }
}
