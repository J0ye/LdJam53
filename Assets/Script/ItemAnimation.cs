using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAnimation : MonoBehaviour
{
    public Vector3 rotateDirection = Vector3.one;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotateDirection);
    }
}
