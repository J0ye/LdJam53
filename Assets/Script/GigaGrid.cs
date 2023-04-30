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

        PlaceTile(position, newTile.GetComponent<Tile>());
        return newTile;
    }

    public GameObject PlaceTile(Vector3Int position, GameObject tilePrefab)
    {
        // get the cell center in world position
        Vector3 worldPosition = grid.GetCellCenterWorld(position);

        var newTile = Instantiate(tilePrefab, worldPosition, Quaternion.identity);

        PlaceTile(position, newTile.GetComponent<Tile>());
        return newTile;
    }

    private void PlaceTile(Vector3Int position, Tile tile)
    {
        print(tile.gameObject.name);
        tile.isPlaced = true;
        if (!tiles.ContainsKey(position))
        {
            tiles.Add(position, tile);
        }
        tile.OnPlace();
    }

    public void RemoveTile(Vector3 position)
    {
        Vector3Int gridPosition = grid.WorldToCell(position);
        RemoveTile(gridPosition);
    }

    public void RemoveTile(Vector3Int position)
    {
        // get the cell center in world position
        Vector3 worldPosition = grid.GetCellCenterWorld(position);
        Tile tile = GetAt(position);
        if(tile == null)
        {
            tiles.Remove(position);
            Destroy(tile.gameObject);
        }
    }

    public Vector3 GetNearestGridPoint(Vector3 point)
    {
        Vector3Int cellPosition = grid.WorldToCell(point);
        return grid.GetCellCenterWorld(cellPosition);
    }
}
