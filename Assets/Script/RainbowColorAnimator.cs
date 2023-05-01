using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class RainbowColorAnimator : MonoBehaviour
{
    public float duration = 2.0f; // Duration of a single color transition

    private SpriteRenderer spriteRenderer;
    private float timer;
    private int colorIndex;
    private Color[] rainbowColors = new Color[]
    {
        Color.red,
        new Color(1, 0.5f, 0), // Orange
        Color.yellow,
        Color.green,
        Color.blue,
        new Color(0.5f, 0, 1), // Indigo
        new Color(0.29f, 0, 0.51f) // Violet
    };

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= duration)
        {
            timer = 0;
            colorIndex = (colorIndex + 1) % rainbowColors.Length;
        }

        Color startColor = rainbowColors[colorIndex];
        Color endColor = rainbowColors[(colorIndex + 1) % rainbowColors.Length];

        float t = timer / duration;
        spriteRenderer.color = Color.Lerp(startColor, endColor, t);
    }
}