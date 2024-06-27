using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class AnswerButton : MonoBehaviour
{
    private ITestManager _manager;
    [SerializeField] private Button _button;
    [SerializeField] private TMP_Text _text;

    public Button Button => _button;

    private StreetInfo _info;
    public StreetInfo Info => _info;


    public void SetInfo(StreetInfo info)
    {
        _info = info;
        _text.text = info.SubjectName;
    }


    [Inject]
    public void Init(ITestManager manager)
    {
        _manager = manager;
        _button.onClick.AddListener(() => _manager.CheckAnswer(this));
    }
}
    