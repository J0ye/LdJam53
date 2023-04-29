using System.Collections;
using System.Collections.Generic;
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
        // clear existing
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        // choose random
        for (int i = 0; i < maxTiles; i++)
        {
            int random = Random.Range(0, possibleTiles.Length);
            var tile = possibleTiles[random];
            var newButton = Instantiate(tileButtonPrefab, gameObject.transform);
            newButton.GetComponent<TileButton>().SetTile(tile);
        }
    }
}
