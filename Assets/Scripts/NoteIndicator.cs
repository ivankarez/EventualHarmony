using UnityEngine;

public class NoteIndicator : MonoBehaviour
{
    [SerializeField] private Color positiveColor;
    [SerializeField] private Color negativeColor;

    [SerializeField] private NoteIndicatorCircle[] circles;

    public void Initialize(float score)
    {
        var color = score > 0 ? positiveColor : negativeColor;

        foreach (var circle in circles)
        {
            circle.SetColor(color);
        }
    }
}
