using UnityEngine;

public class Bar : MonoBehaviour
{
    [SerializeField] private RectTransform root;
    [SerializeField] private RectTransform barGraphics;
    [SerializeField] private float fillSpeed = 0.5f;

    private float value;
    private Vector2 targetSize;

    public float Value
    {
        get => value;
        set
        {
            this.value = Mathf.Clamp01(value);
            targetSize = new Vector2(this.value * root.rect.width, 1);
        }
    }

    private void Update()
    {
        barGraphics.sizeDelta = Vector2.Lerp(barGraphics.sizeDelta, targetSize, fillSpeed * Time.deltaTime);
    }
}
