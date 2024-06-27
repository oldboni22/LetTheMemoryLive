using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Test/Question")]
public class Question : ScriptableObject
{
    [SerializeField] private string _questionText;
    public string QuestionText => _questionText;

    [SerializeField] private StreetInfo[] _answers;
    [SerializeField] private StreetInfo _correct;



    public StreetInfo Correct => _correct;
    
    public IEnumerable<StreetInfo> GetAnswers()
    {
        return _answers.Shuffle();
    }
}

