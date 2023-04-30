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

    public GameObject tileCameraPrefab;

    private RenderTexture tileCameraTexture;

    private GameObject tileCamera;

    private int cameraOffset = 50;

    Tile tile;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetIndex(int index)
    {
        tileCameraTexture = new RenderTexture(new RenderTextureDescriptor(1024, 1024));
        tileCamera = Instantiate(tileCameraPrefab, gameObject.transform);
        tileCamera.transform.position = new Vector3(100.0f + (index * cameraOffset), 0.0f, 100.0f + (index * cameraOffset));
        Camera camera = tileCamera.transform.Find("Camera").gameObject.GetComponent<Camera>();
        camera.targetTexture = tileCameraTexture;
    }

    public void SetTile(Tile tile)
    {
        this.tile = tile;
        // text.text = tile.name;
        GameObject tileClone = Instantiate(tile.gameObject, Vector3.zero, Quaternion.identity, tileCamera.transform);
        tileClone.transform.localPosition = Vector3.zero;
        image.texture = tileCameraTexture;

        //if (this.tile.imageRotation > 0)
        //{
        //    image.transform.Rotate(new Vector3(0.0f, 0.0f, this.tile.imageRotation));
        //}

        //image.texture = tile.imageTexture;
    }

    public void SelectTile()
    {
        GameController.instance.player.SetObjectToPlace(tile.gameObject);
    }
}
