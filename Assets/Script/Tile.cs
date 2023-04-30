using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Tile : MonoBehaviour
{
    public bool isPlaced { get; set; }
    public List<GameObject> walls;

    private void Start()
    {
        walls.ForEach(wall =>
        {
            wall.GetComponent<Wall>().tile = this;
        });
    }
    public virtual void OnPlace()
    {
    }
}
