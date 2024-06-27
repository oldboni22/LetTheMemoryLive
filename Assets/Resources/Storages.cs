using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "Storages", menuName = "Installers/Storages")]
public class Storages : ScriptableObjectInstaller<Storages>
{
    [SerializeField] private StreetInfoStorage _streetInfoStorage;
    [SerializeField] private QuestionStorage _questionStorage;
    public override void InstallBindings()
    {
        Container.Bind<StreetInfoStorage>().FromInstance(_streetInfoStorage).AsSingle().NonLazy();
        Container.Bind<QuestionStorage>().FromInstance(_questionStorage).AsSingle().NonLazy();

    }
}