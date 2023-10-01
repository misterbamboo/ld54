using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuSelection : MonoBehaviour, IPointerExitHandler
{
    [SerializeField]
    UnityEngine.UI.Image background;

    [SerializeField]
    GameObject scrollView;

    [SerializeField]
    ScrollRect scrollRect;

    public ItemPrefabMap[] ItemPrefabMaps { get; private set; }

    public void Start()
    {
        Enable(false);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Enable(false);
    }

    public void ButtonOnClick(MenuItemType menuItemType)
    {
        var prefab = ItemPrefabMaps.Where(p => p.menuItemType == menuItemType).Select(p => p.prefab).First();
        BuildModeController.Instance.ActivateBuildMode(prefab);
        Enable(false);
    }

    public void Enable(bool value)
    {
        background.enabled = value;
        gameObject.GetComponent<UnityEngine.UI.Image>().enabled = value;
        scrollView.SetActive(value);

        scrollRect.verticalNormalizedPosition = 1;
    }

    public void Init(ItemPrefabMap[] itemPrefabMaps)
    {
        ItemPrefabMaps = itemPrefabMaps;
    }
}
