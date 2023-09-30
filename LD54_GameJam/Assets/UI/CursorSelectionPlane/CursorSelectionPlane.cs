using UnityEngine;

public class CursorSelectionPlane : MonoBehaviour
{
    [SerializeField] Transform indicatorPos;
    [SerializeField] int minX = -5;
    [SerializeField] int minZ = -5;
    [SerializeField] int maxX = 4;
    [SerializeField] int maxZ = 4;

    private int CurrentViewedLayer;

    private ILayerNavigation LayerNavigationInstance { get; set; }

    private int cursorSelectionPlaneMask;

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
            point.x = Mathf.Clamp((int)point.x - 1, minX, maxX);
            point.y = (int)point.y;
            point.z = Mathf.Clamp((int)point.z - 1, minZ, maxZ);

            indicatorPos.position = point;
        }
    }
}
