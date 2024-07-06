using UnityEngine;

public class PlayingField : MonoBehaviour
{
    [SerializeField] private float playingFieldSizeX = 3f;
    [SerializeField] private float playingFieldSizeY = 2f;

    public float PlayingFieldSizeX => playingFieldSizeX;

    public Vector3 GetRandomPosition()
    {
        var x = Utils.NormalRandom() * playingFieldSizeX;
        var y = Utils.NormalRandom() * playingFieldSizeY;
        return new Vector3(x, y, 0);
    }
}
