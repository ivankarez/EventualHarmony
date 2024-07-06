using System.Collections;
using UnityEngine;

public class NoteIndicatorCircle : MonoBehaviour
{
    [SerializeField] private float scaleGrowth = 1f;
    [SerializeField] private float startDelay = 0f;
    [SerializeField] private float animationDuration = 1f;
    [SerializeField] private SpriteRenderer circleRenderer;

    private Color startColor;
    private float startScale;

    private void Awake()
    {
        startScale = transform.localScale.x;
    }

    public void SetColor(Color color)
    {
        startColor = color;
        circleRenderer.color = color;
    }

    private void OnEnable()
    {
        StartCoroutine(Animate());
    }

    private void OnDisable()
    {
        StopAllCoroutines();

        circleRenderer.color = startColor;
        transform.localScale = Vector3.one * startScale;
    }

    private IEnumerator Animate()
    {
        yield return new WaitForSeconds(startDelay);
        var targetColor = new Color(startColor.r, startColor.g, startColor.b, 0f);
        var targetScale = startScale + scaleGrowth;

        float timer = 0f;
        while (timer < animationDuration)
        {
            timer += Time.deltaTime;

            circleRenderer.color = Color.Lerp(startColor, targetColor, timer / animationDuration);
            transform.localScale = Vector3.one * Mathf.Lerp(startScale, targetScale, timer / animationDuration);

            yield return null;
        }

        circleRenderer.color = targetColor;
        transform.localScale = Vector3.one * targetScale;
    }
}
