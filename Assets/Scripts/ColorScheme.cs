using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ColorScheme", menuName = "EventualHarmony/Color Scheme")]
public class ColorScheme : ScriptableObject
{
    [SerializeField] private List<Color> colors = new();
    public IReadOnlyList<Color> Colors => colors;
}
