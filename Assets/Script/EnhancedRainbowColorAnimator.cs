using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class EnhancedRainbowColorAnimator : MonoBehaviour
{
    public float duration = 2.0f; // Duration of a single color transition
    public float colorWaveSpeed = 1.0f; // Speed of the color wave

    private SpriteRenderer spriteRenderer;
    private float timer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        float t = Mathf.Sin(timer * colorWaveSpeed);
        t = (t + 1) / 2; // Remap sine wave from [-1, 1] to [0, 1]

        Color startColor = Color.HSVToRGB((timer / duration) % 1, 1, 1);
        Color endColor = Color.HSVToRGB(((timer + 0.5f) / duration) % 1, 1, 1);

        spriteRenderer.color = Color.Lerp(startColor, endColor, t);
    }
}