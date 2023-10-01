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
            UpdateFactoryItemState(previousPos, newPos);
        }
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

    private void UpdateFactoryItemState(Vector3 previousPos, Vector3 newPos)
    {
        if (factoryItem != null)
        {
            // get rotation, inverted
            float radRotationAngle = GetNeededRotation();

            factoryItem.transform.position = newPos;

            Vector3 previousIndexPos = previousPos.ToIndexPos();
            UpdateFlashAndActiveState(previousIndexPos, true);

            var isSlotAvailable = true;
            Vector3 indexPos = newPos.ToIndexPos();
            var takenSpaces = factoryItem.GetTakenSpaces();
            foreach (var space in takenSpaces)
            {
                var lookPos = indexPos + space.Rotate(radRotationAngle);
                if (!mapGrid.IsSlotAvailable(lookPos))
                {
                    isSlotAvailable = false;
                    break;
                }
            }

            UpdateFlashAndActiveState(indexPos, isSlotAvailable);
            UpdateWhenElevator(indexPos);
        }
    }

    private void UpdateWhenElevator(Vector3 indexPos)
    {
        if (factoryItem != null)
        {
            var elevator = factoryItem.GetComponent<Elevator>();
            if (elevator != null)
            {
                bool isBase = true;
                if (indexPos.y > 0)
                {
                    var go = mapGrid.GetGameObject(indexPos - new Vector3(0, 1, 0));
                    if (go != null && ((MonoBehaviour)go).GetComponent<Elevator>())
                    {
                        isBase = false;
                    }
                }

                elevator.ChangeIsBase(isBase);
            }
        }
    }

    private static float GetNeededRotation()
    {
        return -CameraController.Instance.TargetRadAngle - Mathf.PI / 2;
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

    private void PlaceFactoryItem()
    {
        Vector3 indexPos = CursorSelector.Instance.CursorPos.ToIndexPos();
        var isSlotAvailable = mapGrid.IsSlotAvailable(indexPos);

        if (!isSlotAvailable)
        {
            return;
        }

        factoryItem.SetPlaced(true);
        factoryItem.SetFlashing(false);

        float radRotationAngle = GetNeededRotation();
        var takenSpaces = factoryItem.GetTakenSpaces();
        foreach (var space in takenSpaces)
        {
            var lookPos = indexPos + space.Rotate(radRotationAngle);
            mapGrid.SetGameObject(lookPos, factoryItem);
        }

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
