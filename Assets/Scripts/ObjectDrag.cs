using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDrag : MonoBehaviour
{
    [SerializeField] Vector2 initialPos;
    Vector3 mousePos;
    [SerializeField] GameObject dragObject;
    [SerializeField] GameObject tile;

    SpriteRenderer tileSprite;

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
        }

        if (tile == null)
        {
            transform.position = initialPos;
        }

        dragObject = null;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Tile") && gameObject.CompareTag("Player"))
        {
            tile = other.gameObject;
            tileSprite = tile.GetComponent<SpriteRenderer>();
            tileSprite.color = Color.red;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        tile = null;
        tileSprite.color = Color.white;
    }
}
