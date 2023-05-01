using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TileButton : MonoBehaviour
{
    [SerializeField]
    private RawImage image;

    public GameObject tileCameraPrefab;

    private RenderTexture tileCameraTexture;

    private GameObject tileCamera;

    public int cameraOffset = 20;

    Tile tile;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetIndex(int index)
    {
        /*
        tileCameraTexture = new RenderTexture(new RenderTextureDescriptor(1024, 1024));
        tileCamera = Instantiate(tileCameraPrefab, gameObject.transform);
        tileCamera.transform.position = new Vector3(50.0f + (index * cameraOffset), 0.0f, 50.0f + (index * cameraOffset));
        Camera camera = tileCamera.transform.Find("Camera").gameObject.GetComponent<Camera>();
        camera.targetTexture = tileCameraTexture;
        camera.aspect = 1.334f;
        */
    }

    public void SetTile(Tile tile)
    {
        try
        {
            this.tile = tile;
            //GameObject tileClone = Instantiate(tile.gameObject, tileCamera.transform);
            //tileClone.transform.localPosition = Vector3.zero;
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
    }
}
