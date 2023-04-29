using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Car : MonoBehaviour
{
    public float MoveSpeed = 12f;

    private Rigidbody Rb;

    private int packages = 0;

    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            SwitchOrientation(Direction.up);
        }
        else if(Input.GetKey(KeyCode.S))
        {
            SwitchOrientation(Direction.down);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            SwitchOrientation(Direction.left);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            SwitchOrientation(Direction.right);
        }
        transform.position += transform.forward * Time.deltaTime * MoveSpeed;
    }

    public void SwitchOrientation(Direction newOrientation)
    {
        switch(newOrientation)
        {
            case Direction.up:
                transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
                break;
            case Direction.down: 
                transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
                break;
            case Direction.right:
                transform.rotation = Quaternion.Euler(0.0f, 90.0f, 0.0f);
                break;
            case Direction.left:
                transform.rotation = Quaternion.Euler(0.0f, -90.0f, 0.0f);
                break;
            case Direction.none:
                break;
        }
    }

    public void IncreasePackages()
    {
        packages++;
    }

    public void DeliverPackages()
    {
        GameController.instance.AddScore(packages);
        packages = 0;
    }
}

