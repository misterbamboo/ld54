using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MenuSelection : MonoBehaviour, IPointerExitHandler
{
    [SerializeField]
    UnityEngine.UI.Image background;

    [SerializeField]
    GameObject scrollView;

    [SerializeField]
    ScrollRect scrollRect;

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
        print(menuItemType.ToString());
    }

    public void Enable(bool value)
    {
        background.enabled = value;
        gameObject.GetComponent<UnityEngine.UI.Image>().enabled = value;
        scrollView.SetActive(value);

        scrollRect.verticalNormalizedPosition = 1;
    }
}
