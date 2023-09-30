using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private ILayerNavigation LayerNavigationInstance { get; set; }

    private int TargetViewedLayer { get; set; }

    private float time;
    private float startingY;
    private float targetY;

    [SerializeField] Vector3 posOffset;
    [SerializeField] Vector3 rotationOffset;

    void Start()
    {
        LayerNavigationInstance = LayerNavigation.Instance;
        ChangeTargetViewedLayer(0);
    }

    void Update()
    {
        CheckSelectedViewedLayer();
        SmoothCameraMoveToTargetViewedLayer();
        ApplyRotation();
    }

    private void CheckSelectedViewedLayer()
    {
        if (TargetViewedLayer != LayerNavigationInstance.ViewedLayer)
        {
            ChangeTargetViewedLayer(LayerNavigationInstance.ViewedLayer);
            print(LayerNavigationInstance.ViewedLayer);
        }
    }

    private void ChangeTargetViewedLayer(int viewedLayer)
    {
        time = 0f;
        startingY = transform.position.y;
        targetY = viewedLayer + posOffset.y;
        TargetViewedLayer = viewedLayer;
    }

    private void SmoothCameraMoveToTargetViewedLayer()
    {
        if (time >= 1) return;

        time += Time.deltaTime;
        time = Mathf.Clamp(time, 0, 1);

        var t = Easing.EaseOut(time, 5);
        var posY = Mathf.Lerp(startingY, targetY, t);

        ApplyPosition(posY);
    }

    private void ApplyPosition(float posY)
    {
        var pos = transform.position;
        pos.x = posOffset.x;
        pos.z = posOffset.z;
        pos.y = posY;
        transform.position = pos;
    }

    private void ApplyRotation()
    {
        var angles = Quaternion.identity.eulerAngles;
        angles += rotationOffset;
        transform.rotation = Quaternion.Euler(angles);
    }
}
