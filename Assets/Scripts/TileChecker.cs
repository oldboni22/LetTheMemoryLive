using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface ITileChecker
{
    public void Check(Tile tile);
}
public class TileChecker : MonoBehaviour, ITileChecker
{
    [SerializeField] private GameObject _checkerPrefab;

    public void Check(Tile tile)
    {
        if (!tile.IsChecked)
            GameObject.Instantiate(_checkerPrefab, tile.transform);
    }
}
