using TMPro;
using UnityEngine;

public class NoteStatisticsUi : MonoBehaviour
{
    [SerializeField] private TMP_Text[] aliveNoteCountTexts;

    private int[] aliveNoteCounts;

    private void Start()
    {
        aliveNoteCounts = new int[aliveNoteCountTexts.Length];
        for (var i = 0; i < aliveNoteCounts.Length; i++)
        {
            aliveNoteCountTexts[i].text = "0";
        }
    }

    public void IncrementAliveNoteCount(int note)
    {
        aliveNoteCounts[note]++;
        aliveNoteCountTexts[note].text = aliveNoteCounts[note].ToString();
    }

    public void DecrementAliveNoteCount(int note)
    {
        aliveNoteCounts[note]--;
        aliveNoteCountTexts[note].text = aliveNoteCounts[note].ToString();
    }
}
