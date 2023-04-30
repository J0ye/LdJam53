using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Tile : MonoBehaviour
{
    public bool isPlaced { get; private set; }
    public UnityEvent onPlaced = new UnityEvent();

    public void IsPlaced(bool state)
    {
        if(state)
        {
            onPlaced.Invoke();
        }
        isPlaced = state;
    }

}
