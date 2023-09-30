using UnityEngine;

public class LayerVisibility : MonoBehaviour
{
    void Start()
    {
        LayerNavigation.Instance.OnLayerChanged += Instance_OnLayerChanged;
    }

    private void Instance_OnLayerChanged(int viewedLayer)
    {
        gameObject.SetActive(transform.position.y <= viewedLayer);
    }

    void Update()
    {

    }
}
