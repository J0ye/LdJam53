using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteTile : Tile
{
    public override void OnPlace()
    {
        GameController.instance.gigaGrid.RemoveTile(transform.position);
    }
}
