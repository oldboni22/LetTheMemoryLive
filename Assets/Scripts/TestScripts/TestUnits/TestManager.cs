using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Zenject;


public interface ITestManager
{
    public void CheckAnswer(AnswerButton button);
}

public class TestManager : MonoBehaviour, ITestManager
{

    [SerializeField] private int _questionsCount;

    private IQuestionUiManager _questionUiManager;
    private IAnimationManager _animationManager;
    private IResultUIManager _resultUIManager;
    private IInfoUIManager _infoUi;
    private IProgressBarController _progressBarController;

    private int _correctCount = 0;

    private Question[] _questions;
    private int _curQuestionIndex = 0;
    private Question CurQuestion => _questions[_curQuestionIndex];

    [Inject]
    public void Init(IQuestionUiManager questionUiManager, IAnimationManager animationManager ,QuestionStorage questionStorage, IResultUIManager resultUIManager, IInfoUIManager infoUI, IProgressBarController progressBarController)
    {
        _questionUiManager = questionUiManager;
        _animationManager = animationManager;
        _resultUIManager = resultUIManager;
        _infoUi = infoUI;
        _progressBarController = progressBarController;

        _questions = questionStorage.GetQuestionPool(_questionsCount).ToArray();
        for (int i = 0; i < _questionsCount; i++)
            _progressBarController.Add();
        _progressBarController.Highlight(_curQuestionIndex);
        _questionUiManager.LoadQuestion(CurQuestion);
    }

    public void CheckAnswer(AnswerButton button)
    {

        StartCoroutine(NextQuestionTransition(button.Info == CurQuestion.Correct));
        
    }
    private IEnumerator NextQuestionTransition(bool correct)
    {
        if (correct)
        {
            _correctCount++;
        }

        bool finalize = (_curQuestionIndex == _questionsCount - 1);
        
        _animationManager.StartAnimation(correct, finalize);
        _questionUiManager.ToggleButtons(false);
        _progressBarController.SetCurrentColor(correct);

        yield return new WaitUntil(() => _animationManager.BlinkEnded);

        if (correct is false)
            _infoUi.DisplayInfo(CurQuestion.Correct.Name);

        yield return new WaitUntil(() => _animationManager.FlashEnded);
        if (!finalize)
        {

            _curQuestionIndex++;
            _questionUiManager.ToggleButtons(true);
            _progressBarController.Highlight(_curQuestionIndex);
            _questionUiManager.LoadQuestion(CurQuestion);
        }
        else
        {
            Finalize();
        }

    }
    public void Finalize()
    {
        _resultUIManager.DisplayResult(_correctCount,_questionsCount);
    }
}
