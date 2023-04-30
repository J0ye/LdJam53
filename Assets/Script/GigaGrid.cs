using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class GigaGrid : MonoBehaviour
{
    Dictionary<Vector3Int, Tile> tiles = new Dictionary<Vector3Int, Tile>();

    Grid grid;

    private void Awake()
    {
        grid = GetComponent<Grid>();
    }

    public bool IsValidPlacement(Vector3 worldPosition, GameObject tileObj)
    {
        bool isValid = true;
        Tile tile;
        tileObj.TryGetComponent<Tile>(out tile);
        if (tile.consumesSpace)
        {
            Vector3Int position = grid.WorldToCell(worldPosition);
            if (tiles.ContainsKey(position))
            {
                isValid = false;
            }
        }
        return isValid;
    }

    public Tile GetAt(Vector3Int position)
    {
        Tile tile = null;
        if (tiles.ContainsKey(position))
            tile = tiles[position];
        
        return tile;
    }

    public GameObject PlaceTile(Vector3 worldPosition, GameObject tilePrefab)
    {
        // get the cell center in world position
        Vector3Int position = grid.WorldToCell(worldPosition);
        Vector3 worldPositionCenter = grid.GetCellCenterWorld(position);

        var newTile = Instantiate(tilePrefab, worldPositionCenter, Quaternion.identity);

        return PlaceTile(position, newTile.GetComponent<Tile>());
    }

    public GameObject PlaceTile(Vector3Int position, GameObject tilePrefab)
    {
        // get the cell center in world position
        Vector3 worldPosition = grid.GetCellCenterWorld(position);

        var newTile = Instantiate(tilePrefab, worldPosition, Quaternion.identity);

        return PlaceTile(position, newTile.GetComponent<Tile>());
    }

    private GameObject PlaceTile(Vector3Int position, Tile tile)
    {
        if (tile.BeforePlace())
        {
            tile.isPlaced = true;
            if (!tiles.ContainsKey(position))
            {
                tiles.Add(position, tile);
            }
            tile.OnPlace();

            return tile.gameObject;
        }
        else
        {
            Destroy(tile.gameObject);
        }
        return null;
    }

    public bool RemoveTile(Vector3 position)
    {
        Vector3Int gridPosition = grid.WorldToCell(position);
        return RemoveTile(gridPosition);
    }

    public bool RemoveTile(Vector3Int position)
    {
        // get the cell center in world position
        Vector3 worldPosition = grid.GetCellCenterWorld(position);
        Tile tile = GetAt(position);
        if(tile != null)
        {
            tiles.Remove(position);
            Destroy(tile.gameObject);
            return true;
        }
        return false;
    }

    public Vector3 GetNearestGridPoint(Vector3 point)
    {
        Vector3Int cellPosition = grid.WorldToCell(point);
        return grid.GetCellCenterWorld(cellPosition);
    }
}
