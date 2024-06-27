
using UnityEngine;
using UnityEngine.UI;

public class TypeToggle : MonoBehaviour
{
    [SerializeField] private Button _streetButton, _placeButton;

    private void Awake()
    {
        _streetButton.onClick.AddListener(() => Toggle(_streetButton));
        _placeButton.onClick.AddListener(() => Toggle(_placeButton));
    }

    void Toggle(Button sender)
    {
        if(sender == _streetButton)
        {
            _streetButton.interactable = false;
            _placeButton.interactable = true;
        }
        else
        {
            _placeButton.interactable = false;
            _streetButton.interactable = true;
        }
    }

}
