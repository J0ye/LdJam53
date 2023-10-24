using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TileChooser : MonoBehaviour
{
    public TileButton tileInHand;
    [SerializeField]
    private Tile[] possibleTiles;

    [SerializeField]
    private GameObject tileButtonPrefab;

    [SerializeField]
    private int maxTiles;

    protected List<Tile> tiles = new List<Tile>();
    protected List<TileButton> inHand = new List<TileButton>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(inHand.Count >= 3)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                inHand[0].SelectTile();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                inHand[1].SelectTile();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                inHand[2].SelectTile();
            }
        }
    }

    public void GenerateRandomTiles()
    {
        tiles = new List<Tile>();
        inHand = new List<TileButton>();
        // clear existing
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        // choose random
        for (int i = 0; i < maxTiles; i++)
        {
            Tile tile = GetRandom();
            if (tile.TryGetComponent<DirectionTile>(out DirectionTile directionTile))
            {
                for(int j = 0; j < 2; j++) // Repeat check two times. oops, its hard coded 
                {
                    if (tiles.Where(i => i.GetComponent<DirectionTile>()?.direction == directionTile.direction).Any() || directionTile.direction == GameController.instance.car.drivingDirection)
                    {
                        // retry
                        tile = GetRandom();
                    }
                }
            }

            GameObject newButton = Instantiate(tileButtonPrefab, gameObject.transform);
            tiles.Add(tile);
            TileButton tileButton = newButton.GetComponent<TileButton>();
            tileButton.tileChooser = this;
            tileButton.SetTile(tile);
            inHand.Add(tileButton);
        }
    }

    public void DrawNewCard()
    {
        if(tileInHand)
        {
            //Remove old card from lists
            tiles.Remove(tileInHand.GetTargetTileAsTile());
            inHand.Remove(tileInHand);
            //Destroy button obejct
            Destroy(tileInHand.gameObject);

            // choose new random
            Tile tile = GetRandom();
            if (tile.TryGetComponent<DirectionTile>(out DirectionTile directionTile))
            {
                for (int j = 0; j < 3; j++) // Repeat check three times. oops, its hard coded 
                {
                    if (tiles.Where(i => i.GetComponent<DirectionTile>()?.direction == directionTile.direction).Any() || directionTile.direction == GameController.instance.car.drivingDirection)
                    {
                        // retry
                        tile = GetRandom();
                    }
                }
            }

            GameObject newButton = Instantiate(tileButtonPrefab, gameObject.transform);
            tiles.Add(tile);
            TileButton tileButton = newButton.GetComponent<TileButton>();
            tileButton.tileChooser = this;
            tileButton.SetTile(tile);
            inHand.Add(tileButton);
        }
    }

    public Tile GetRandom()
    {
        return possibleTiles[Random.Range(0, possibleTiles.Length)];
    }
}
