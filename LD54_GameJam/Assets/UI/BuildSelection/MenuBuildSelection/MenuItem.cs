using TMPro;
using UnityEngine;

public class MenuItem : MonoBehaviour
{
    [SerializeField]
    MenuItemType menuItemType;

    MenuSelection menuSelection;

    public void Start()
    {
        menuSelection = gameObject.GetComponentInParent<MenuSelection>();
        gameObject.GetComponentInChildren<TextMeshProUGUI>().text = menuItemType.ToString();
    }

    public void OnClick()
    { 
        menuSelection.ButtonOnClick(menuItemType);
    }
}

public enum MenuItemType
{
    ExtractorRed,
    ExtractorBlue,
    ExtractorYellow,
    Belt,
    Storage,
    Elevator,
    Forge,
    Splitter,
    Merger,
    Garbage
}
