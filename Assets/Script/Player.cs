using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Player : MonoBehaviour
{
    public LayerMask lm = new LayerMask();
    [SerializeField]
    GigaGrid gigaGrid;
    private GameObject _objectToPlace;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Start is called before the first frame update
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_objectToPlace != null)
        {
            //show object and snap to grid
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, lm))
            {
                Debug.Log(hit.transform.name);
                var point = gigaGrid.GetNearestGridPoint(hit.point);
                //place object on mouse pos
                _objectToPlace.transform.position = point;

                //actually place object when left clicking
                if (Input.GetMouseButtonDown(0))
                {
                    //spawn tower on server
                    PlaceObjectOnTile(point, _objectToPlace);
                    _objectToPlace = null;
                }
            }
        }
    }

    public void SetObjectToPlace(GameObject tile)
    {
        Destroy(_objectToPlace);
        _objectToPlace = Instantiate(tile);
    }

    void PlaceObjectOnTile(Vector3 point, GameObject tile)
    {
        gigaGrid.PlaceTile(point, tile);
        Destroy(_objectToPlace);

        // Generate new tiles to choose frmo
        UIController.instance.tileChooser.GenerateRandomTiles();
    }
}
