using UnityEngine;

public class MusicalityScoreUI : MonoBehaviour
{
    [SerializeField] private Bar positiveBar;
    [SerializeField] private Bar negativeBar;

    public void SetMusicalityScore(float score)
    {
        if (score >= 0)
        {
            positiveBar.Value = score;
            negativeBar.Value = 0;
        }
        else
        {
            positiveBar.Value = 0;
            negativeBar.Value = -score;
        }
    }
}
