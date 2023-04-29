using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction { right, left, up, down, none }

[RequireComponent(typeof(Tile))]
public class DirectionTile : MonoBehaviour
{
    public Direction direction;

    public void OnTriggerEnter(Collider other)
    {
        if (gameObject.GetComponent<Tile>().isPlaced)
        {
            print("collision");
            Car target;
            if (other.gameObject.TryGetComponent<Car>(out target))
            {
                print("isCar");
                // if other has Car component; go here
                target.SwitchOrientation(direction);
            }
        }
    }
}
