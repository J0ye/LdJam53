using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCrash : MonoBehaviour
{

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall") && collision.gameObject.GetComponent<Wall>().tile.isPlaced == true)
        {
            print("Here");
            transform.parent.GetComponent<Car>().enabled = false;
            transform.parent.GetComponent<Car>().PlayCrashSound();
            GameController.instance.EndLevel();
        }
    }
}
