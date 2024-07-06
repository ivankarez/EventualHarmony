using UnityEngine;
using UnityEngine.UI;

public class PianoKey : MonoBehaviour
{
    [SerializeField] private Image graphics;
    [SerializeField] private ColorScheme colorScheme;

    public int NoteIndex
    {
        get => noteIndex;
        set
        {
            noteIndex = value;
            highlightColor = colorScheme.Colors[noteIndex];
        }
    }

    private Color defaultColor;
    private Color highlightColor;
    private int noteIndex;

    private void Start()
    {
        defaultColor = graphics.color;
    }

    private void Update()
    {
        graphics.color = Color.Lerp(graphics.color, defaultColor, Time.deltaTime * 5);
    }

    public void PlayNoteAnimation()
    {
        graphics.color = highlightColor;
    }
}
