using UnityEngine;
using Zenject;

public class TestInstaller : MonoInstaller
{
    [SerializeField] TestManager _testManager;
    [SerializeField] AnimationManager _animationManager;
    [SerializeField] QuestionUiManager _questionUiManager;
    [SerializeField] ResultUIManager _resultUIManager;
    [SerializeField] InfoUIManager _infoUIManager;
    [SerializeField] ProgressBarController _progressBarController;
    public override void InstallBindings()
    {
        Container.Bind<ITestManager>().To<TestManager>().FromInstance(_testManager).AsSingle().NonLazy();
        Container.Bind<IAnimationManager>().To<AnimationManager>().FromInstance(_animationManager).AsSingle().NonLazy();
        Container.Bind<IQuestionUiManager>().To<QuestionUiManager>().FromInstance(_questionUiManager).AsSingle().NonLazy();
        Container.Bind<IResultUIManager>().To<ResultUIManager>().FromInstance(_resultUIManager).AsSingle().NonLazy();
        Container.Bind<IInfoUIManager>().To<InfoUIManager>().FromInstance(_infoUIManager).AsSingle().NonLazy();
        Container.Bind<IProgressBarController>().To<ProgressBarController>().FromInstance(_progressBarController).AsSingle().NonLazy();
        
    }
}