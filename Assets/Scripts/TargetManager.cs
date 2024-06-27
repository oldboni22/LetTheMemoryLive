using UnityEngine;
using Zenject;

public interface ITargetManager
{
    public void Hover(Tile tile);
    public void UnHover();
}
public class TargetManager : MonoBehaviour, ITargetManager
{
    [Inject] private ICameraManager _cameraManager;

    public void Hover(Tile tile)
    {
        _cameraManager.CameraHover(tile.transform);
    }
    public void UnHover()
    {
        _cameraManager.RessetCamera();
    }

}

