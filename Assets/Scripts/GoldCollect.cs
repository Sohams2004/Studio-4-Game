using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCollect : MonoBehaviour
{
    public Camera camera;

    public GameObject objectHit;

    public float rayLength = 4f;
    public float goldAmount;

    [SerializeField] LayerMask goldLayer;
    AudioSource goldCollectAudio;

    GoldManager goldManager;

    private void Start()
    {
        goldCollectAudio = GetComponent<AudioSource>();
        goldManager = FindObjectOfType<GoldManager>();
    }

    void Update()
    {
        Vector2 ray = camera.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray, Vector2.zero, rayLength, goldLayer);

        if (hit)
        {
            objectHit = hit.collider.gameObject;
            CollectGold();
        }

        else
        {
            objectHit = null;
        }

        Debug.Log(Physics.Raycast(ray,Vector2.zero, rayLength, goldLayer));
    }

    void CollectGold()
    {
        if(Input.GetMouseButtonDown(0))
        {
            goldCollectAudio.Play();
            goldManager.goldAmount += goldAmount;
            Destroy(objectHit);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
    }
}
