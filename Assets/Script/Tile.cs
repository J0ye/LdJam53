using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction { right, left, up, down, none}

public class Tile : MonoBehaviour
{
    public bool isPlaced { get; set; }
    public Direction direction;

    public void OnTriggerEnter(Collider other)
    {
        print("collision");
        Car target;
        if(other.gameObject.TryGetComponent<Car>(out target))
        {
            print("isCar");
            // if other has Car component; go here
            target.SwitchOrientation(direction);

        }
    }
}
