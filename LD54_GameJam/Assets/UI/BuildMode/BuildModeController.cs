using System;
using Unity.VisualScripting;
using UnityEngine;

public interface IBuildModeController
{
    event Action OnFactoryItemPlaced;

    bool IsBuildModeActivated { get; }

    void ActivateBuildMode(FactoryItem FactoryItemPrefab);

    void AbortBuildMode();
}

public class BuildModeController : MonoBehaviour, IBuildModeController
{
    public static IBuildModeController Instance { get; private set; }

    public bool IsBuildModeActivated { get => factoryItem != null; }
    private FactoryItem factoryItem;

    [SerializeField] Transform mapParent;
    private MapGrid mapGrid;

    public event Action OnFactoryItemPlaced;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        CursorSelector.Instance.OnCursorPosChanged += Instance_OnCursorPosChanged1;
        CameraController.Instance.OnTargetRadAngleChanged += Instance_OnTargetRadAngleChanged;
        mapGrid = MapGridController.Instance.MapGrid;
    }

    private void Instance_OnTargetRadAngleChanged()
    {
        if (factoryItem != null)
        {
            ChangeFactoryItemRotation();
        }
    }

    private void ChangeFactoryItemRotation()
    {
        var angles = Quaternion.identity.eulerAngles;
        angles.y = (-CameraController.Instance.TargetRadAngle - Mathf.PI / 2) * Mathf.Rad2Deg;

        factoryItem.transform.rotation = Quaternion.Euler(angles);
    }

    private void Instance_OnCursorPosChanged1(Vector3 previousPos, Vector3 newPos)
    {
        if (factoryItem != null)
        {
            RefreshFactoryItem(previousPos, newPos);
        }
    }

    private void RefreshFactoryItem(Vector3 previousPos, Vector3 newPos)
    {
        UpdateFactoryItemState(previousPos, newPos);
        factoryItem.transform.position = CursorSelector.Instance.CursorPos;
    }

    void Update()
    {
        if (IsBuildModeActivated)
        {
            if (Input.GetMouseButtonDown(0))
            {
                PlaceFactoryItem();
            }
        }
    }

    public void ActivateBuildMode(FactoryItem FactoryItemPrefab)
    {
        factoryItem = Instantiate(FactoryItemPrefab, gameObject.transform);
        factoryItem.transform.position = CursorSelector.Instance.CursorPos;
        factoryItem.SetFlashing(false);
        ChangeFactoryItemRotation();
    }

    public void AbortBuildMode()
    {
        Destroy(factoryItem.gameObject);
        factoryItem = null;
    }

    private void UpdateFactoryItemState(Vector3 previousPos, Vector3 cursorPos)
    {
        if (factoryItem != null)
        {
            Vector3 previousIndexPos = ToIndexPos(previousPos);
            UpdateFlashAndActiveState(previousIndexPos, true);

            Vector3 indexPos = ToIndexPos(cursorPos);
            var isSlotAvailable = mapGrid.IsSlotAvailable(indexPos);
            UpdateFlashAndActiveState(indexPos, isSlotAvailable);
        }
    }

    private void UpdateFlashAndActiveState(Vector3 indexPos, bool isSlotAvailable)
    {
        if (isSlotAvailable)
        {
            factoryItem.gameObject.SetActive(true);
            mapGrid.SetSlotFlashing(indexPos, false);
        }
        else
        {
            factoryItem.gameObject.SetActive(false);
            mapGrid.SetSlotFlashing(indexPos, true);
        }
    }

    private static Vector3 ToIndexPos(Vector3 cursorPos)
    {
        return cursorPos + new Vector3(5, 0, 5);
    }

    private void PlaceFactoryItem()
    {
        Vector3 indexPos = ToIndexPos(CursorSelector.Instance.CursorPos);
        var isSlotAvailable = mapGrid.IsSlotAvailable(indexPos);

        if (!isSlotAvailable)
        {
            return;
        }

        factoryItem.SetPlaced(true);
        factoryItem.SetFlashing(false);
        mapGrid.SetGameObject(indexPos, factoryItem);

        factoryItem.transform.SetParent(mapParent, true);

        var layerVisibilityScript = factoryItem.GetComponent<LayerVisibility>();
        if (layerVisibilityScript == null)
        {
            factoryItem.AddComponent<LayerVisibility>();
        }

        factoryItem = null;
        OnFactoryItemPlaced?.Invoke();
    }
}
