using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CarAnimation : MonoBehaviour
{
    [Header("Wobble Options")]
    public float duration = 1f;
    public float wobbleDuration = 1f;
    public float wobbleStrength = 0.1f;
    public int vibrato = 7;
    public int wobbleVibrato = 7;
    public float wobbleRandomness = 200;
    public Vector3 punchDirection = Vector3.up;


    private Tween tween;
    private Tween wobble;
    // Start is called before the first frame update
    void Start()
    {
        StartPunch();
    }

    // Update is called once per frame
    void Update()
    {

        if (!tween.active)
        {
            StartPunch();
        }
    }
    public void StartWobble()
    {
        wobble = transform.DOShakeScale(wobbleDuration, wobbleStrength, wobbleVibrato, wobbleRandomness, false);
    }

    public void StartPunch()
    {
        tween = transform.DOPunchScale(punchDirection, duration, vibrato, wobbleStrength);
    }
}
