using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;




[CreateAssetMenu(menuName = "Test/QuestionPool")]
public class QuestionStorage : ScriptableObject
{
    [SerializeField] private Question[] _questinPool;

    public IEnumerable<Question> GetQuestionPool(int poolSize)
    {
        return _questinPool.Shuffle().Take(poolSize);
    }

}
