using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
    Extractor,
    Belt,
    Forge,
    Splitter,
    Merger,
    Storage,
    Garbage
}
