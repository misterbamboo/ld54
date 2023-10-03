using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SideMenuItem : MonoBehaviour
{   
    [SerializeField] MenuItemType menuItemType;

    SideMenuBuildSelection sideMenuBuildSelection;

    void Start()
    {
        sideMenuBuildSelection = gameObject.GetComponentInParent<SideMenuBuildSelection>();
    }

    public void OnClick()
    {
        sideMenuBuildSelection.ButtonOnClick(menuItemType);
    }
}
