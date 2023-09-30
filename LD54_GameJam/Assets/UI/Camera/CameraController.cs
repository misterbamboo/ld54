using UnityEngine;

public class CameraController : MonoBehaviour
{
    private ILayerNavigation LayerNavigationInstance { get; set; }

    private int TargetViewedLayer { get; set; }

    private float layerAnimTime;
    private float startingY;
    private float targetY;

    [SerializeField] float yOffset = 8;
    [SerializeField] float lookAtYOffset = 2;
    [SerializeField] float distOffset = 5;

    private float angleAnimTime;
    private float startingRadAngle;
    private float targetRadAngle;

    void Start()
    {
        LayerNavigationInstance = LayerNavigation.Instance;
        ChangeTargetViewedLayer(0);
    }

    void Update()
    {
        ChackRotationChanged();
        SmoothCameraMoveToAngle();

        CheckViewedLayerChanged();
        SmoothCameraMoveToTargetViewedLayer();
    }

    private void CheckViewedLayerChanged()
    {
        if (TargetViewedLayer != LayerNavigationInstance.ViewedLayer)
        {
            ChangeTargetViewedLayer(LayerNavigationInstance.ViewedLayer);
        }
    }

    private void ChackRotationChanged()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            angleAnimTime = 0;
            startingRadAngle = targetRadAngle;
            targetRadAngle += Mathf.PI / 2;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            angleAnimTime = 0;
            startingRadAngle = targetRadAngle;
            targetRadAngle -= Mathf.PI / 2;
        }
    }

    private void ChangeTargetViewedLayer(int viewedLayer)
    {
        layerAnimTime = 0f;
        startingY = transform.position.y - yOffset;
        targetY = viewedLayer;
        TargetViewedLayer = viewedLayer;
    }

    private void SmoothCameraMoveToTargetViewedLayer()
    {
        layerAnimTime += Time.deltaTime;
        layerAnimTime = Mathf.Clamp(layerAnimTime, 0, 1);

        var t = Easing.EaseOut(layerAnimTime, 5);
        var posY = Mathf.Lerp(startingY, targetY, t);

        var pos = transform.position;
        pos.y = posY + yOffset;
        transform.position = pos;

        transform.LookAt(Vector3.zero + new Vector3(0, posY + lookAtYOffset, 0));
    }

    private void SmoothCameraMoveToAngle()
    {
        angleAnimTime += Time.deltaTime;
        angleAnimTime = Mathf.Clamp(angleAnimTime, 0, 1);

        var t = Easing.EaseOut(angleAnimTime, 5);
        var radAngle = Mathf.Lerp(startingRadAngle, targetRadAngle, t);

        var x = Mathf.Cos(radAngle) * distOffset;
        var z = Mathf.Sin(radAngle) * distOffset;

        var pos = transform.position;
        pos.x = x;
        pos.z = z;
        transform.position = pos;
    }
}
