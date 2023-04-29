using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TileButton : MonoBehaviour
{
    [SerializeField]
    private TMP_Text text;

    [SerializeField]
    private RawImage image;

    Tile tile;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetTile(Tile tile)
    {
        this.tile = tile;
        text.text = tile.name;

        image.texture = tile.imageTexture;

        if(this.tile.imageRotation > 0)
        {
            transform.Rotate(new Vector3(0.0f, 0.0f, this.tile.imageRotation));
        }
    }

    public void SelectTile()
    {
        GameController.instance.player.SetObjectToPlace(tile.gameObject);
    }
}
