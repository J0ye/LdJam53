using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TileButton : MonoBehaviour
{
    [SerializeField]
    private TMP_Text text;

    Tile tile;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetTile(Tile tile)
    {
        this.tile = tile;
        text.text = tile.name;
    }

    public void SelectTile()
    {
        GameController.instance.player.SetObjectToPlace(tile.gameObject);
    }
}
