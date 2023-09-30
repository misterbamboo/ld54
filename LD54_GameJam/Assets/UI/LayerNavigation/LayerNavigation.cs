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

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        OnLayerChanged(0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            ViewedLayer++;
            OnLayerChanged(ViewedLayer);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            ViewedLayer = Mathf.Clamp(ViewedLayer - 1, 0, int.MaxValue);
            OnLayerChanged(ViewedLayer);
        }
    }
}
