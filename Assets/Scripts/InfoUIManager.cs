using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public interface IInfoUIManager
{
    public void DisplayInfo(string streetName);
}
public class InfoUIManager : MonoBehaviour, IInfoUIManager
{
    private StreetInfoStorage _streetInfoStorage;
    [SerializeField] private InfoUi _ui;

    [Inject]
    public void Init(StreetInfoStorage streetInfoStorage)
    {
        _streetInfoStorage = streetInfoStorage;
    }
    public void DisplayInfo(string streetName)
    {
        var streetInfo = _streetInfoStorage.GetByName(streetName);

        _ui.gameObject.SetActive(true); 
        _ui.Expand(streetInfo);
    }
    public void Collapse()
    {
        _ui.Collapse();
    }
}
