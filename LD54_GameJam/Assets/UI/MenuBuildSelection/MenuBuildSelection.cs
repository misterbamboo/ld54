using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MenuBuildSelection : MonoBehaviour
{
    [SerializeField]
    UnityEngine.UI.Image background;

    [SerializeField]
    MenuSelection menuSelection;

    public void Update()
    {
        // on mouse click move menu selection to mouse position
        if (Input.GetMouseButtonDown(0))
        {
            if(menuSelection.GetComponent<UnityEngine.UI.Image>().enabled)
            {
                return;
            }

            var menuPos = Input.mousePosition;

            background.enabled = true;
            menuSelection.Enable(true);
            
            background.GetComponent<RectTransform>().position = menuPos + new Vector3(-20f, 20f, 0);
        }
    }
}
