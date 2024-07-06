using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoringSystem : MonoBehaviour
{
    private readonly float[] intervalScores = { 1, -1, -1, 1, -1, -1, -1, 1, -1, -1, 1, -1 };
    private readonly Queue<ScoreHistoryItem> scoreHistory = new();

    [SerializeField] private float scoreHistoryDuration = 10f;
    [SerializeField] private IntervalsUI intervalsUI;
    [SerializeField] private MusicalityScoreUI musicalityScoreUI;

    private void Start()
    {
        intervalsUI.Initialize(intervalScores);
    }

    public float CalculateScore(int noteA, int noteB)
    {
        var interval = Mathf.Abs(noteA - noteB);
        intervalsUI.PlayIntervalAnimation(interval);
        var score = intervalScores[interval];
        UpdateScoreHistory(score);

        return score;
    }

    private void UpdateScoreHistory(float score)
    {
        var currentTime = Time.realtimeSinceStartup;
        while (scoreHistory.Count > 0 && scoreHistory.Peek().Time < currentTime - scoreHistoryDuration)
        {
            scoreHistory.Dequeue();
        }

        scoreHistory.Enqueue(new ScoreHistoryItem { Score = score, Time = currentTime });
        var musicalityScore = scoreHistory.Average(item => item.Score);
        musicalityScoreUI.SetMusicalityScore(musicalityScore);
    }
}

class ScoreHistoryItem
{
    public float Score { get; set; }
    public float Time { get; set; }
}
