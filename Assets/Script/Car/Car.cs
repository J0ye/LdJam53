using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Car : MonoBehaviour
{
    [Tooltip("This vector represents the maximum values that the speed of the car can have. X = lowest possible speed. Y = highest possible speed.")]
    public Vector2 speedBounds = new Vector2(1f, 3f);
    [Tooltip("The amount of speed that gets added to the movement speed each frame")]
    public float acceleration = 0.01f;
    [Tooltip("This value is used to decrease the speed when turning. The current gets subtracted by this value at every turn. never below min speed.")]
    public float turnBreakingValue = 2f;
    public float turnSpeed = 1f;
    public CarAnimation carAnimation;
    /// <summary>
    /// The direction the car is going at this moment
    /// </summary>
    public Direction drivingDirection = Direction.none;
    public bool onGrid = true;
    public GameObject followParcelPrefab;
    [HideInInspector]
    public bool doMove = true;

    private Rigidbody Rb;
    private Ray downCastRay;
    public List<GameObject> followers = new List<GameObject>();

    private Tween turnTween;
    private int packages = 0;
    public float drivingSpeed { get; private set; }
    public bool debugControls = true;

    [SerializeField]
    private AudioClip tireScreechSound;
    [SerializeField]
    private AudioClip crashSound;
    [SerializeField]
    private AudioClip deliverSound;
    [SerializeField]
    private AudioClip packageSound;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        #region grid check
        downCastRay = new Ray(transform.position, Vector3.down);
        // Check if car is still on grid
        onGrid = Physics.Raycast(downCastRay);
        if(!onGrid)
        {
            doMove = false;
            Rb.isKinematic = false;
            Rb.useGravity = true;
            GameController.instance.EndLevel();
        }
        #endregion
        if(debugControls)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                SwitchOrientation(Direction.up, true);
            }
            else if (Input.GetKeyDown(KeyCode.S))
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
        }

        if(turnTween != null)
        {
            if (!turnTween.active && !doMove && onGrid)
            {
                // Do move the car when there is no turning animation
                doMove = true;
                carAnimation.SwitchTireTrackState(false);
            }
        }
        if (doMove)
        {
            SetDrivingSpeed(drivingSpeed + acceleration);
            transform.position += transform.forward * Time.deltaTime * drivingSpeed;
        }
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
            case Direction.reverse:
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles - new Vector3(0.0f, 180.0f, 0.0f));
                break;
            case Direction.none:
                break;
        }
        SetDrivingSpeed(drivingSpeed - turnBreakingValue);
        drivingDirection = newOrientation;
    }
    public void SwitchOrientation(Direction newOrientation, bool doAnimation)
    {
        if(!doAnimation)
        {
            SwitchOrientation(newOrientation);
        }
        doMove = false;
        carAnimation.SwitchTireTrackState(true);
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
            case Direction.reverse:
                Vector3 target = transform.rotation.eulerAngles - new Vector3(0.0f, 180.0f, 0.0f);
                turnTween = transform.DORotate(target, turnSpeed);
                break;
            case Direction.none:
                break;
        }
        drivingDirection = newOrientation;
        SetDrivingSpeed(drivingSpeed - turnBreakingValue);

        audioSource.PlayOneShot(tireScreechSound);
    }
    public void IncreasePackages()
    {
        GameObject newFollower = Instantiate(followParcelPrefab, transform.position, Quaternion.identity);
        followers.Add(newFollower);
        FollowCar followComponent = newFollower.GetComponent<FollowCar>();
        followComponent.car = gameObject;
        followComponent.positionInChain = followers.Count;
        packages++;

        audioSource.PlayOneShot(packageSound);
    }

    public bool DeliverPackages()
    {
        if(packages > 0)
        {
            foreach (var temp in followers)
                Destroy(temp);

            followers = new List<GameObject>();
            GameController.instance.AddScore(packages);
            packages = 0;

            audioSource.PlayOneShot(deliverSound);
            return true;
        }
        else
        {
            return false;
        }
    }

    public void PlayCrashSound()
    {
        audioSource.PlayOneShot(crashSound);
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(downCastRay);
    }

    public void SetDrivingSpeed(float newVal)
    {
        drivingSpeed = newVal;
        drivingSpeed = Mathf.Clamp(drivingSpeed, speedBounds.x, speedBounds.y);
    }
}

