using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;


public class Tile : MonoBehaviour
{
    public enum type
    {
        Street,
        Place,
    }


    [SerializeField] private GameObject _indicator;

    [SerializeField] private string _tileName;
    public string TileName => _tileName;
    
    [SerializeField] private type _type;
    public type Type => _type;

    public bool IsChecked
    {
        get
        {
            if (!_isChecked)
            {
                _isChecked = true;
                return false;
            }
            else return true;
        }
    }
    private bool _isChecked = false;
    public void ShowIndicator() => _indicator?.SetActive(true);
    public void HideIndicator() => _indicator?.SetActive(false);

}
