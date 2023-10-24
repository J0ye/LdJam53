using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCoolDownTileDelete : ButtonCoolDownTileCount
{
    public Tile tile;

    protected override void Start()
    {
        base.Start();
    }

    public void SelectTile()
    {
        GameController.instance.player.SetObjectToPlace(tile.gameObject);
    }
}
