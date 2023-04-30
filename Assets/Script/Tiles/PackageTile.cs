using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Tile))]
public class PackageTile : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Car>(out Car car))
        {
            // give the package to car
            car.IncreasePackages();

            // destroy the package object
            Destroy(gameObject);
        }
    }
}
