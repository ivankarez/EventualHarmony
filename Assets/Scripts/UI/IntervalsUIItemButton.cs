using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class IntervalsUIItemButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private Image graphics;
    [SerializeField] private Color preferedColor;
    [SerializeField] private Color avoidColor;

    private bool isIntervalPrefered;
    private Color defaultColor;
    private Color highlightColor;

    public bool IsIntervalPrefered {
        get => isIntervalPrefered;
        set
        {
            isIntervalPrefered = value;
            highlightColor = isIntervalPrefered ? preferedColor : avoidColor;
            text.text = IsIntervalPrefered ? "Prefer" : "Avoid";
        }
    }
    public Action<float> IntervalScoreChangedAction { get; set; }

    private void Start()
    {
        defaultColor = graphics.color;
    }

    private void Update()
    {
        graphics.color = Color.Lerp(graphics.color, defaultColor, Time.deltaTime * 5);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        IsIntervalPrefered = !IsIntervalPrefered;
        IntervalScoreChangedAction?.Invoke(IsIntervalPrefered ? 1 : -1);
    }

    public void PlayAnimation()
    {
        graphics.color = highlightColor;
    }
}
