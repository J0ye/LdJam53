using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCar : MonoBehaviour
{
    public GameObject car; // Assign the car GameObject in the Inspector
    public float minDistance = 5.0f; // Set the minimum distance you want to maintain
    public float followSpeed = 1.0f; // Set the follow speed
    public int positionInChain = 1;

    private Vector3 previousCarPosition;
    private Vector3 offsetDirection;

    private void Start()
    {
        previousCarPosition = car.transform.position;
    }

    private void Update()
    {
        Vector3 carPosition = car.transform.position;
        Vector3 carDirection = carPosition - previousCarPosition;

        if (carDirection.magnitude > 0.001f) // Check if the car has moved
        {
            carDirection.Normalize();
            offsetDirection = Vector3.Lerp(offsetDirection, carDirection, Time.deltaTime * followSpeed);
            Vector3 targetPosition = carPosition - (offsetDirection * minDistance) *positionInChain;

            transform.position = targetPosition;
        }

        previousCarPosition = carPosition;
    }
}
