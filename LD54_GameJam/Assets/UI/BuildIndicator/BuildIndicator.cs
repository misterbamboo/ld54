using UnityEngine;

public class BuildIndicator : MonoBehaviour
{
    [SerializeField] Material baseMaterial;
    [SerializeField] MeshRenderer planeMeshRenderer;

    private Material flashingMaterial;
    private float time;
    private float baseAlpha;

    private IBuildModeController buildModeControllerInstance;

    void Start()
    {
        LayerNavigation.Instance.OnLayerChanged += Instance_OnLayerChanged;

        planeMeshRenderer.material = flashingMaterial = new Material(baseMaterial);
        baseAlpha = planeMeshRenderer.material.color.a;

        buildModeControllerInstance = BuildModeController.Instance;
    }

    private void Update()
    {
        if (buildModeControllerInstance.IsBuildModeActivated)
        {
            time += Time.deltaTime;
            if (time > Mathf.PI)
            {
                time -= Mathf.PI;
            }

            var t = Mathf.Sin(time);
            var col = flashingMaterial.color;
            col.a = Mathf.Lerp(0, baseAlpha, t);
            flashingMaterial.color = col;
            planeMeshRenderer.material = flashingMaterial;
        }
        else
        {
            time = 0;
            var col = flashingMaterial.color;
            col.a = 0;
            flashingMaterial.color = col;
            planeMeshRenderer.material = flashingMaterial;
        }
    }

    private void Instance_OnLayerChanged(int layer)
    {
        var pos = transform.position;
        pos.y = layer - 0.5f + 0.01f;
        transform.position = pos;
    }
}
