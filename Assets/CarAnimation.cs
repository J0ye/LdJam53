using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CarAnimation : MonoBehaviour
{
    [Header("Wobble Options")]
    public float duration = 1f;
    public float wobbleStrength = 0.1f;
    public int vibrato = 7;
    public float wobbleRandomness = 200;


    private Tween tween;
    // Start is called before the first frame update
    void Start()
    {
        StartWobble();
    }

    // Update is called once per frame
    void Update()
    {

        if (!tween.active)
        {
            StartWobble();
        }
    }
    public void StartWobble()
    {
        tween = transform.DOShakeScale(duration, wobbleStrength, vibrato, wobbleRandomness, false);
    }
}
