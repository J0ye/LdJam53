using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostTile : DirectionTile
{
    [Tooltip("This value gets added to the speed on activation")]
    public float speedBoost = 0.5f;

    public override void OnTriggerEnter(Collider other)
    {
        if (gameObject.GetComponent<Tile>().isPlaced)
        {
            Car target;
            if (other.gameObject.TryGetComponent<Car>(out target))
            {
                print("make car go fast");
                if(target.drivingDirection != direction)
                {
                    // if other has Car component; go here
                    target.SwitchOrientation(direction, true);
                }
                target.SetDrivingSpeed(target.drivingSpeed * speedBoost);
            }
        }
    }
}
