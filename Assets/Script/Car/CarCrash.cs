using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCrash : MonoBehaviour
{

    public void OnCollisionEnter(Collision collision)
    {
        print("Here");
        transform.parent.GetComponent<Car>().enabled = false;
        if (collision.gameObject.CompareTag("Wall"))
        {
            GameController.instance.EndLevel();
        }
    }
}
