using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public interface IResultUIManager
{
    public void DisplayResult(int correctCount, int totalCount);
}

public class ResultUIManager : MonoBehaviour, IResultUIManager
{

    
    [SerializeField] private Transform _UiTransform;

    [SerializeField] private float _animationDur;

    [SerializeField] private Slider _totalSlider;
    [SerializeField] private Slider _correctSlider;
    [SerializeField] private Slider _incorrectSlider;

    [SerializeField] private TMP_Text _totalCount;
    [SerializeField] private TMP_Text _correctCount;
    [SerializeField] private TMP_Text _incorrectCount;


    public void DisplayResult(int correctCount, int totalCount)
    {

        _totalSlider.maxValue = totalCount;
        _correctSlider.maxValue = totalCount;
        _incorrectSlider.maxValue = totalCount;

        _totalSlider.value = totalCount;
        _correctSlider.value = correctCount;
        _incorrectSlider.value = totalCount - correctCount;

        _totalCount.text = $"{totalCount}";
        _correctCount.text = $"{correctCount}";
        _incorrectCount.text = $"{totalCount - correctCount}";

        _UiTransform.gameObject.SetActive(true);
        _UiTransform.DOScale(Vector3.one, _animationDur);
    }
}
