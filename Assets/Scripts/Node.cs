using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Node parent;

    public GameObject nodeGameObject { get; private set; }

    public bool isOcupied = false;
}
