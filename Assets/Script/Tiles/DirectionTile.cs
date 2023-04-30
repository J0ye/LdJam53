using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction { right, left, up, down, reverse, none }

[RequireComponent(typeof(Tile))]
public class DirectionTile : MonoBehaviour
{
    public Direction direction;
    public int durabillity = 3;

    public void OnTriggerEnter(Collider other)
    {
        if (gameObject.GetComponent<Tile>().isPlaced)
        {
            Car target;
            if (other.gameObject.TryGetComponent<Car>(out target) && durabillity > 0)
            {
                // if other has Car component; go here
                target.SwitchOrientation(direction, true);
                durabillity--;

                if(durabillity <= 0)
                {

                }
            }
        }
    }
}
