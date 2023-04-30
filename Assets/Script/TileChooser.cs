using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TileChooser : MonoBehaviour
{
    [SerializeField]
    private Tile[] possibleTiles;

    [SerializeField]
    private GameObject tileButtonPrefab;

    [SerializeField]
    private int maxTiles; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateRandomTiles()
    {
        List<Tile> tiles = new List<Tile>();
        // clear existing
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        // choose random
        for (int i = 0; i < maxTiles; i++)
        {
            var tile = GetRandom();
            if (tile.TryGetComponent<DirectionTile>(out DirectionTile directionTile))
            {
                if (tiles.Where(i => i.GetComponent<DirectionTile>()?.direction == directionTile.direction).Any())
                {
                    // retry
                    tile = GetRandom();
                }
            }

            var newButton = Instantiate(tileButtonPrefab, gameObject.transform);
            tiles.Add(tile);
            newButton.GetComponent<TileButton>().SetIndex(i);
            newButton.GetComponent<TileButton>().SetTile(tile);
        }
    }

    public Tile GetRandom()
    {
        return possibleTiles[Random.Range(0, possibleTiles.Length)];
    }
}
