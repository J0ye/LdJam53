using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteTile : Tile
{

    private void Start()
    {
        consumesSpace = false;
    }
    public override bool BeforePlace()
    {
        var removedSomething = GameController.instance.gigaGrid.RemoveTile(transform.position);
        if(removedSomething)
        {
            //Destroy(gameObject);
            // Remove active tile selection from player
            GameController.instance.player.RemoveObjectToPlace();
            // Generate new tiles to choose frmo
            UIController.instance.tileChooser.GenerateRandomTiles();
        }
        return false;
    }

}
