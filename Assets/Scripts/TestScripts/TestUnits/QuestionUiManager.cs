using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public interface IQuestionUiManager
{
    public void LoadQuestion(Question question);
    public void ToggleButtons(bool state);
}
public class QuestionUiManager : MonoBehaviour, IQuestionUiManager
{
    [SerializeField] private AnswerButton[] _buttons;
    [SerializeField] TMP_Text _text;

    public void LoadQuestion(Question question)
    {
        var answers = question.GetAnswers().ToArray();

        _text.text = question.QuestionText;
        for (int i = 0; i < 4; i++)
        {
            _buttons[i].SetInfo(answers[i]);
            _buttons[i].Button.image.sprite = answers[i].HeroSprite;
        }

    }

    public void ToggleButtons(bool state)
    {
        _buttons.ToggleAll(state);
    }
}
