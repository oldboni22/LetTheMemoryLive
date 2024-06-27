
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;


public class StreetListElement : MonoBehaviour
{
    private Color _originalColor;

    [SerializeField] private Button _button;
    
    [SerializeField] private TMP_Text _text;
    public string AssociatedTileName => _text.text;

    private bool _isChecked = false;

    private StreetListController _controller;

    public void Init(StreetListController listController, string text)
    {
        _controller = listController;
        _text.text = text;
    }

    private void Start()
    {
        _originalColor = _text.color;
    }
    public void OnClick()
    {
        _controller.SelectTile(this);
    }
    public void ToggleButton()
    {
        _button.interactable = false;
        Highlight();
    }
    public void ResetToggle()
    {
        _button.interactable = true;
        ResetColor();
    }
    void Highlight()
    {
        _text.DOKill();
        _text.DOColor(Color.yellow,.65f).SetLoops(-1,LoopType.Yoyo);
    }
    void ResetColor()
    {
        Color color;
        color = _isChecked ? Color.red : _originalColor;

        _text.DOKill();
        _text.DOColor(color, .65f);
    }
    public void Check()
    {
        _isChecked = true;
    }
}
