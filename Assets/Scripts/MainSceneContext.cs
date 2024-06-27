using System.ComponentModel;
using UnityEngine;
using Zenject;

public class MainSceneContext : MonoInstaller
{
    [SerializeField] private TargetManager _targetManager;
    [SerializeField] CameraManager _cameraManager;
    [SerializeField] StreetListController _streetListController;
    [SerializeField] TileManager _tileManager;
    [SerializeField] InfoUIManager _infoUIManager;
    [SerializeField] TileChecker _tileChecker;

    public override void InstallBindings()
    {
        Container.Bind<ITileManager>().To<TileManager>().FromInstance(_tileManager).AsSingle().NonLazy();
        
        Container.Bind<ITargetManager>().To<TargetManager>().FromInstance(_targetManager).AsSingle().NonLazy();
        Container.Bind<ICameraManager>().To<CameraManager>().FromInstance(_cameraManager).AsSingle().NonLazy();
        Container.Bind<IStreetListController>().To<StreetListController>().FromInstance(_streetListController).AsSingle().NonLazy();
        
        Container.Bind<IInfoUIManager>().To<InfoUIManager>().FromInstance(_infoUIManager).AsSingle().NonLazy();
        Container.Bind<ITileChecker>().To<TileChecker>().FromInstance(_tileChecker).AsSingle().NonLazy();
    }
}   