
using UnityEngine;
using Zenject;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using System.Linq;

public interface IStreetListController
{
    public void Resset();

}
public class StreetListController : MonoBehaviour, IStreetListController
{
    private StreetListElement _selectedElement;

    private ITargetManager _targetManager;
    private ITileManager _tileManager;
    private IInfoUIManager _infoUIManager;
    private ITileChecker _tileChecker;

    [SerializeField] private Button _ressetButton;
    [SerializeField] private TMP_InputField _searchField;

    private readonly List<StreetListElement> _elements = new List<StreetListElement>();

    [Header("ElementsSpawn")]
    [SerializeField] private Transform _streetPanelTransfrom;
    [SerializeField] private Transform _placePanelTransfrom;
    [SerializeField] private GameObject _prefab;

    [Inject]
    public void Init(ITargetManager targetManager, ITileManager tileManager, IInfoUIManager infoUIManager, ITileChecker tileChecker)
    {
        _targetManager = targetManager;
        _tileManager = tileManager;
        _infoUIManager = infoUIManager;
        _tileChecker = tileChecker;

        

        foreach (var streetName in _tileManager.GetAllNames(Tile.type.Street))
            InstatiateElement(streetName, _streetPanelTransfrom);


        foreach (var placeName in _tileManager.GetAllNames(Tile.type.Place))
            InstatiateElement(placeName, _placePanelTransfrom);
    }
    private void Start()
    {
        _searchField.onValueChanged.AddListener(Search);
    }
    public void OnTileSelect()
    {
        if (_selectedElement == null)
            return;

        var selectedTile = _tileManager.GetByName(_selectedElement.AssociatedTileName);
        _tileChecker.Check(selectedTile);
        _selectedElement.Check();

        var streetName = _selectedElement.AssociatedTileName;
        _infoUIManager.DisplayInfo(streetName);
    }
    void InstatiateElement(string text, Transform transformGroup)
    {
        var element = GameObject.Instantiate(_prefab, transformGroup).GetComponent<StreetListElement>();
        element.Init(this, text);
        _elements.Add(element);


    }
    public void SelectTile(StreetListElement element)
    {
        if (_selectedElement != null)
        {
            var prevTile = _tileManager.GetByName(_selectedElement.AssociatedTileName);
            prevTile.HideIndicator();
        }

        var tile = _tileManager.GetByName(element.AssociatedTileName);

        tile.ShowIndicator();

        _selectedElement?.ResetToggle();

        _selectedElement = element;
        _selectedElement.ToggleButton();
        _targetManager.Hover(tile);

        _ressetButton.interactable = true;
    }
    public void Resset()
    {
        var prevTile = _tileManager.GetByName(_selectedElement.AssociatedTileName);
        prevTile.HideIndicator();
        _selectedElement?.ResetToggle();
        _selectedElement = null;
        _targetManager.UnHover();

        _ressetButton.interactable = false;
    }
    void Search(string query)
    {
        foreach (var item in _elements)
        {
            if(item.AssociatedTileName.ToLower().Contains(query.ToLower()) is false)
            {
                item.gameObject.SetActive(false);
            }
            else
            {
                item.gameObject.SetActive(true);
            }
        }
    }
}
