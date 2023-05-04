using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TileButton : MonoBehaviour
{
    public RawImage image;
    public GameObject tileCameraPrefab;
    public int cameraOffset = 20;
    public TileChooser tileChooser;

    private RenderTexture tileCameraTexture;
    private Tile tile;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetTile(Tile tile)
    {
        try
        {
            this.tile = tile;
            image.texture = tileCameraTexture;
            if (tile.uiImage != null)
            {
                image.texture = tile.uiImage;
            }
        }
        catch(System.Exception e)
        {
            Debug.LogError("Error with Tile " + tile.gameObject.name + ": " + e);
        }

    }

    public void SelectTile()
    {
        GameController.instance.player.SetObjectToPlace(tile.gameObject);
        tileChooser.tileInHand = this;
    }

    /// <summary>
    /// Returns this buttons tile
    /// </summary>
    /// <returns>This tile as Tile object</returns>
    public Tile GetTargetTileAsTile()
    {
        return tile;
    }
}
