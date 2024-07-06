using UnityEngine;

public class IntervalsUI : MonoBehaviour
{
    [SerializeField] private IntervalsUIItem[] items;

    public void Initialize(float[] intervalScores)
    {
        for (int i = 0; i < items.Length; i++)
        {
            var itemIndex = i;
            items[itemIndex].Button.IsIntervalPrefered = intervalScores[itemIndex] > 0;
            items[itemIndex].Button.IntervalScoreChangedAction = (newScore) => intervalScores[itemIndex] = newScore;
        }
    }

    public void PlayIntervalAnimation(int interval)
    {
        items[interval].PlayIntervalAnimation();
    }
}
