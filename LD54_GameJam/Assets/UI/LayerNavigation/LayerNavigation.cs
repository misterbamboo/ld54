using System;
using UnityEngine;

public interface ILayerNavigation
{
    int ViewedLayer { get; }

    event Action<int> OnLayerChanged;
}

public class LayerNavigation : MonoBehaviour, ILayerNavigation
{
    public static ILayerNavigation Instance => _instance;

    private static LayerNavigation _instance;

    public event Action<int> OnLayerChanged;

    public int ViewedLayer { get; private set; }

    private bool layerInit = false;

    private void Awake()
    {
        _instance = this;
    }

    private void Update()
    {
        if (!layerInit)
        {
            layerInit = true;
            OnLayerChanged?.Invoke(0);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            ViewedLayer++;
            OnLayerChanged?.Invoke(ViewedLayer);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            ViewedLayer = Mathf.Clamp(ViewedLayer - 1, 0, int.MaxValue);
            OnLayerChanged?.Invoke(ViewedLayer);
        }
    }
}
