using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Player : GridOperator
{

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
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                var point = GetNearestGridPoint(hit.point);
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
        _objectToPlace = Instantiate(tile);
    }

    void PlaceObjectOnTile(Vector3 point, GameObject tile)
    {
        tile.GetComponent<Tile>().IsPlaced(true);
        UIController.instance.tileChooser.GenerateRandomTiles();
    }
}
