using UnityEngine;

public class PianoUI : MonoBehaviour
{
    [SerializeField] private PianoKey[] pianoKeys;

    private void Start()
    {
        for (int i = 0; i < pianoKeys.Length; i++)
        {
            pianoKeys[i].NoteIndex = i;
        }
    }

    public void PlayNoteAnimation(int noteIndex)
    {
        pianoKeys[noteIndex].PlayNoteAnimation();
    }
}
