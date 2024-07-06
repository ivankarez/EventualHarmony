using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteIndicatorPool : MonoBehaviour
{
    [SerializeField] private NoteIndicator prefab;
    [SerializeField] private int preloadCount;

    private readonly Queue<NoteIndicator> pool = new();

    private void Awake()
    {
        for (var i = 0; i < preloadCount; i++)
        {
            CreateNewNoteIndicator();
        }
    }

    private void CreateNewNoteIndicator()
    {
        var noteIndicator = Instantiate(prefab, transform);
        noteIndicator.gameObject.SetActive(false);
        pool.Enqueue(noteIndicator);
    }

    public void ShowNoteIndicator(float score, Vector3 position)
    {
        if (pool.Count == 0)
        {
            CreateNewNoteIndicator();
        }

        var noteIndicator = pool.Dequeue();
        noteIndicator.gameObject.SetActive(true);
        StartCoroutine(ReturnNoteIndicator(noteIndicator));
        noteIndicator.transform.position = position;
        noteIndicator.Initialize(score);
    }

    private IEnumerator ReturnNoteIndicator(NoteIndicator noteIndicator)
    {
        yield return new WaitForSeconds(1);
        noteIndicator.gameObject.SetActive(false);
        pool.Enqueue(noteIndicator);
    }
}
