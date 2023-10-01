using System;
using UnityEngine;

public interface ICursorSelector
{
    Vector3 CursorPos { get; }

    event CursorSelectorChanged OnCursorPosChanged;
}

public class CursorSelector : MonoBehaviour, ICursorSelector
{
    public static ICursorSelector Instance { get; private set; }

    [SerializeField] int minX = -5;
    [SerializeField] int minZ = -5;
    [SerializeField] int maxX = 4;
    [SerializeField] int maxZ = 4;

    private int CurrentViewedLayer;

    private ILayerNavigation LayerNavigationInstance { get; set; }
    public Vector3 CursorPos { get; private set; }

    private int cursorSelectionPlaneMask;

    public event CursorSelectorChanged OnCursorPosChanged;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        LayerNavigationInstance = LayerNavigation.Instance;
        cursorSelectionPlaneMask = LayerMask.GetMask("CursorSelectionPlaneMask");
    }

    void Update()
    {
        CheckPlaneYPos();
        MousePos();
    }

    private void CheckPlaneYPos()
    {
        if (CurrentViewedLayer != LayerNavigationInstance.ViewedLayer)
        {
            CurrentViewedLayer = LayerNavigationInstance.ViewedLayer;
            var pos = transform.position;
            pos.y = CurrentViewedLayer;
            transform.position = pos;
        }
    }

    private void MousePos()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100, cursorSelectionPlaneMask))
        {
            var point = hit.point;
            point.x = Mathf.FloorToInt(Mathf.Clamp(point.x, minX, maxX));
            point.y = (int)point.y;
            point.z = Mathf.FloorToInt(Mathf.Clamp(point.z, minZ, maxZ));

            if (CursorPos != point)
            {
                var previousPos = CursorPos;
                CursorPos = point;
                OnCursorPosChanged?.Invoke(previousPos, CursorPos);
            }
        }
    }
}

public delegate void CursorSelectorChanged(Vector3 previousPos, Vector3 newPos);