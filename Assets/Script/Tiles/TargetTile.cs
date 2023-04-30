using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetTile : MonoBehaviour
{
    public bool showLine = true;

    protected LineRenderer line;
    protected bool hasLine = false;
    // Start is called before the first frame update
    void Awake()
    {    
        hasLine = TryGetComponent<LineRenderer>(out line);
    }

    // Update is called once per frame
    void Update()
    {
        if(hasLine && showLine)
        {
            line.SetPosition(0, transform.position);
            line.SetPosition(1, GameController.instance.car.transform.position);
        }
    }
}
