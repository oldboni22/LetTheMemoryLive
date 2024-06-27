using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class InfoUi : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Image _subjectImage;
    [SerializeField] private TMP_Text _nameText;
    [SerializeField] private TMP_Text _descriptionText;

    public void Expand(StreetInfo info)
    {
        SetInfo(info);
        transform.DOScale(1f, .45f);
    }
    public void Collapse() 
    {
        transform.DOScale(0f, .45f).OnComplete(() => gameObject.SetActive(false));
    }

    void SetInfo(StreetInfo info)
    {
        _image.sprite = info.HeroSprite;
        _subjectImage.sprite = info.SubjectSprite;

        _nameText.text = info.SubjectName;
        _descriptionText.text = info.Info;
    }
}
