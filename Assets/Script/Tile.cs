using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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

}
