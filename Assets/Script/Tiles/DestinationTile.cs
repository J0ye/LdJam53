using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Tile))]
public class DestinationTile : TargetTile
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Car>(out Car car))
        {
            // give the package to car
            if(car.DeliverPackages())
            {
                // Only destroy the package if delivery was successful
                Destroy(gameObject);
            }
        }
    }
}
