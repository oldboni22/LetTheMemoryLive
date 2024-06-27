using UnityEngine;
using Zenject;

public class MainInstaller : MonoInstaller
{
    public SceneManager _sceneManager;
    public override void InstallBindings()
    {
        Container.Bind<ISceneManager>().To<SceneManager>().FromInstance(_sceneManager).AsSingle().NonLazy();
    }
}