using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Tile : MonoBehaviour
{
    public bool isPlaced { get; set; }

    private void Start()
    {
        foreach (Wall child in transform.GetComponentsInChildren<Wall>())
        {
            child.tile = this;
        }
    }
    public virtual void OnPlace()
    {
    }
}
