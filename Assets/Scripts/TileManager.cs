using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public interface ITileManager
{
    public Tile GetByName(string name);
    public string[] GetAllNames();
    public string[] GetAllNames(Tile.type type);
}
public class TileManager : MonoBehaviour, ITileManager
{

    [SerializeField] private GameObject _mapParent;
    private Tile[] _tiles;

    [Inject]
    public void Init()
    {
        _tiles = _mapParent.GetComponentsInChildren<Tile>();
    }

    public string[] GetAllNames() => _tiles.Select(t => t.TileName).ToArray();

    public string[] GetAllNames(Tile.type type) => _tiles.Where(t => t.Type == type).Select(t => t.TileName).Sort().ToArray();

    public Tile GetByName(string name) => _tiles.SingleOrDefault(t => t.TileName == name);
}
