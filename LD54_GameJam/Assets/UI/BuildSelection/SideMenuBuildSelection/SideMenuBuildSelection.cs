using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class SideMenuBuildSelection : MonoBehaviour
{
    [SerializeField] ItemPrefabMap[] ItemPrefabMaps;

    public void ButtonOnClick(MenuItemType menuItemType)
    {
        var prefab = ItemPrefabMaps.Where(p => p.menuItemType == menuItemType).Select(p => p.prefab).First();
        BuildModeController.Instance.ActivateBuildMode(prefab);
    }
}
