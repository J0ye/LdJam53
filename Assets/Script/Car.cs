using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Car : MonoBehaviour
{
    public float MoveSpeed = 12f;
    public float turnSpeed = 1f;

    private Rigidbody Rb;

    private Tween turnTween;
    private int packages = 0;
    private bool doMove = true;

    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            SwitchOrientation(Direction.up, true);
        }
        else if(Input.GetKeyDown(KeyCode.S))
        {
            SwitchOrientation(Direction.down, true);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            SwitchOrientation(Direction.left, true);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            SwitchOrientation(Direction.right, true);
        }

        if(turnTween != null)
        {
            if (!turnTween.active && !doMove)
            {
                // Do move the car when there is no turning animation
                doMove = true;
            }
        }
        if (doMove) transform.position += transform.forward * Time.deltaTime * MoveSpeed;
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
    public void SwitchOrientation(Direction newOrientation, bool doAnimation)
    {
        if(!doAnimation)
        {
            SwitchOrientation(newOrientation);
        }
        doMove = false;
        switch (newOrientation)
        {
            case Direction.up:
                turnTween = transform.DORotate(Vector3.zero, turnSpeed);
                break;
            case Direction.down:
                turnTween = transform.DORotate(new Vector3(0f, 180, 0f), turnSpeed);
                break;
            case Direction.right:
                turnTween = transform.DORotate(new Vector3(0f, 90f, 0f), turnSpeed);
                break;
            case Direction.left:
                turnTween = transform.DORotate(new Vector3(0f, -90, 0f), turnSpeed);
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

