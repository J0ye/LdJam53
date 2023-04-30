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
        // text.text = tile.name;

        if (this.tile.imageRotation > 0)
        {
            image.transform.Rotate(new Vector3(0.0f, 0.0f, this.tile.imageRotation));
        }

        image.texture = tile.imageTexture;
    }

    public void SelectTile()
    {
        GameController.instance.player.SetObjectToPlace(tile.gameObject);
    }
}
