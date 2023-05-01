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

    public int cameraOffset = 2;

    Tile tile;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetIndex(int index)
    {
        tileCameraTexture = new RenderTexture(new RenderTextureDescriptor(1024, 1024));
        tileCamera = Instantiate(tileCameraPrefab, gameObject.transform);
        tileCamera.transform.position = new Vector3(5.0f + (index * cameraOffset), 0.0f, 5.0f + (index * cameraOffset));
        Camera camera = tileCamera.transform.Find("Camera").gameObject.GetComponent<Camera>();
        camera.targetTexture = tileCameraTexture;
    }

    public void SetTile(Tile tile)
    {
        this.tile = tile;
        GameObject tileClone = Instantiate(tile.gameObject, tileCamera.transform);
        tileClone.transform.localPosition = Vector3.zero;
        image.texture = tileCameraTexture;
    }

    public void SelectTile()
    {
        GameController.instance.player.SetObjectToPlace(tile.gameObject);
    }
}
