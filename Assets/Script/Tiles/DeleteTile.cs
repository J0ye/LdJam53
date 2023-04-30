using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteTile : Tile
{
    public LayerMask lm = new LayerMask();
    public List<Tile> tiles = new List<Tile>();

    private void Start()
    {
        onPlaced.AddListener(DeleteTargetTile);
    }

    public void DeleteTargetTile()
    {
        Collider[] targets = Physics.OverlapBox(transform.position, transform.localScale/2, Quaternion.identity, lm);
        print("Found target: " + targets.Length);
        foreach (Collider rh in targets)
        {
            if(rh.TryGetComponent<Tile>(out Tile targetTile))
            {
                Destroy(rh.gameObject);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, Vector3.one);
    }
}
