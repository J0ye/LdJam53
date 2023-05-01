using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Texture uiImage;
    public bool isPlaced { get; set; }

    public bool consumesSpace = true;

    private void Start()
    {
        foreach (Wall child in transform.GetComponentsInChildren<Wall>())
        {
            child.tile = this;
        }
    }
    public virtual bool BeforePlace()
    {
        return true;
    }

    public virtual void OnPlace()
    {

    }
}
