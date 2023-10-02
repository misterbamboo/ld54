using UnityEngine;

public class MenuBuildSelection : MonoBehaviour
{
    [SerializeField]
    UnityEngine.UI.Image background;

    [SerializeField]
    MenuSelection menuSelection;

    [SerializeField] ItemPrefabMap[] itemPrefabMaps;

    private void Start()
    {
        menuSelection.Init(itemPrefabMaps);
    }

    public void Update()
    {
        // on mouse click move menu selection to mouse position
        if (Input.GetMouseButtonDown(1))
        {
            BuildModeController.Instance.AbortBuildMode();

            if (menuSelection.GetComponent<UnityEngine.UI.Image>().enabled)
            {
                return;
            }

            var menuPos = Input.mousePosition;

            background.enabled = true;
            menuSelection.Enable(true);

            var rectTransform = background.GetComponent<RectTransform>();
            rectTransform.position = menuPos + new Vector3(rectTransform.sizeDelta.x / -2, rectTransform.sizeDelta.y / 2, 0);
        }
    }
}
