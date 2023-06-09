using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridOperator : MonoBehaviour
{
    public Grid grid;
    public Vector3Int gridSize;
    [HideInInspector]
    public List<Vector3> edgeCellsWorldPositions = new List<Vector3>();
    [HideInInspector]
    public List<Vector3> innerCellsWorldPositions = new List<Vector3>();

    protected virtual void Awake()
    {
        GetCellsWorldPositions();
    }

    public List<Vector3> GetCellsWorldPositions()
    {
        edgeCellsWorldPositions = new List<Vector3>();

        for (int x = -gridSize.x; x < gridSize.x; x++)
        {
            for (int y = 0; y < gridSize.y; y++)
            {
                for (int z = -gridSize.z; z < gridSize.z; z++)
                {
                    bool isEdgeCell = x == -gridSize.x || x == gridSize.x - 1 ||                          
                                      z == -gridSize.z || z == gridSize.z - 1;

                    if (isEdgeCell)
                    {
                        Vector3Int cellCoordinates = new Vector3Int(x, y, z);
                        Vector3 worldPosition = grid.GetCellCenterWorld(cellCoordinates);
                        edgeCellsWorldPositions.Add(worldPosition);
                    }
                    else
                    {
                        Vector3Int cellCoordinates = new Vector3Int(x, y, z);
                        Vector3 worldPosition = grid.GetCellCenterWorld(cellCoordinates);
                        innerCellsWorldPositions.Add(worldPosition);
                    }
                }
            }
        }

        return edgeCellsWorldPositions;
    }

    public Vector3 GetRandomEdgeCellPosition()
    {
        int rand = Random.Range(0, edgeCellsWorldPositions.Count);

        return edgeCellsWorldPositions[rand];
    }

    public Vector3 GetRandomInnerCellPosition()
    {
        int rand = Random.Range(0, innerCellsWorldPositions.Count);

        return innerCellsWorldPositions[rand];
    }
}
