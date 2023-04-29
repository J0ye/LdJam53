using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Tile))]
public class DestinationTile : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Car>(out Car car))
        {
            // give the package to car
            car.DeliverPackages();

            // destroy the package object
            Destroy(gameObject);
        }
    }
}
