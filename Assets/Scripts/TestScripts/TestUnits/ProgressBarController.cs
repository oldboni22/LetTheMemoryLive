using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public interface IProgressBarController
{
    public void Add();
    public void Highlight(int ind);
    public void SetCurrentColor(bool correct);
}
public class ProgressBarController : MonoBehaviour, IProgressBarController
{
    private readonly List<Image> _images = new List<Image>();
    private int curInd = 0;

    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform _panel;

    public void Add()
    {
        var img = GameObject.Instantiate(_prefab, _panel).GetComponent<Image>();
        _images.Add(img);
    }

    public void Highlight(int ind)
    {
        curInd = ind;
        _images[curInd].color = Color.white;
    }

    public void SetCurrentColor(bool correct)
    {
        var col = correct? Color.green: Color.red;
        col.a = .75f;
        _images[curInd].color = col;
    }
}
