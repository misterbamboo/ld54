using UnityEngine;

public interface IMapGridController
{
    MapGrid MapGrid { get; }
}

public class MapGridController : MonoBehaviour, IMapGridController
{
    public static IMapGridController Instance;

    private MapGrid grid;

    public MapGrid MapGrid => grid;

    private void Awake()
    {
        Instance = this;
        grid = new MapGrid();
    }

    void Start()
    {
        LayerNavigation.Instance.OnLayerChanged += Instance_OnLayerChanged;
    }

    private void Instance_OnLayerChanged(int layer)
    {
        grid.AddLayersUntils(layer);
    }
}
