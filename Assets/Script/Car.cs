using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public float MoveSpeed = 12f;

    private Rigidbody Rb;

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
            SwitchOrientation(Direction.forward);
        }
        else if(Input.GetKey(KeyCode.S))
        {
            SwitchOrientation(Direction.backwards);
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
            case Direction.forward:
                transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
                break;
            case Direction.backwards: 
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
}
