using UnityEngine;

public class IntervalsUIItem : MonoBehaviour
{
    [SerializeField] private IntervalsUIItemButton button;

    public IntervalsUIItemButton Button => button;

    public void PlayIntervalAnimation()
    {
        button.PlayAnimation();
    }
}
