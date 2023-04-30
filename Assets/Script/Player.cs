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
                var point = gigaGrid.GetNearestGridPoint(hit.point);
                //place object on mouse pos
                _objectToPlace.transform.position = point;

                //actually place object when left clicking
                if (Input.GetMouseButtonDown(0))
                {
                    //spawn tower on server
                    PlaceObjectOnTile(point, _objectToPlace);
                    
                }
            }
        }
    }

    public void SetObjectToPlace(GameObject tile)
    {
        RemoveObjectToPlace();
        _objectToPlace = Instantiate(tile);
    }

    public void RemoveObjectToPlace()
    {
        Destroy(_objectToPlace);
    }

    void PlaceObjectOnTile(Vector3 point, GameObject tile)
    {
        if (gigaGrid.IsValidPlacement(point, tile))
        {
            var success = gigaGrid.PlaceTile(point, tile);
            if(success != null)
            {
                Destroy(_objectToPlace);
                _objectToPlace = null;

                // Generate new tiles to choose frmo
                UIController.instance.tileChooser.GenerateRandomTiles();
            }
        }
    }
}
