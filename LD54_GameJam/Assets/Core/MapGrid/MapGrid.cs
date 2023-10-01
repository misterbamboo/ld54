using System.Collections.Generic;
using UnityEngine;

public class MapGrid
{
    private List<MapGridSlot[,]> mapGridSlots = new List<MapGridSlot[,]>();

    public void AddLayersUntils(int layer)
    {
        var missingLayers = (layer + 1) - mapGridSlots.Count;
        if (missingLayers > 0)
        {
            for (int y = 0; y < missingLayers; y++)
            {
                var layerSlots = new MapGridSlot[10, 10];
                FillLayerSlots(layerSlots);
                mapGridSlots.Add(layerSlots);
            }
        }
    }

    private void FillLayerSlots(MapGridSlot[,] layerSlots)
    {
        for (int x = 0; x < layerSlots.GetLength(0); x++)
        {
            for (int z = 0; z < layerSlots.GetLength(1); z++)
            {
                layerSlots[x, z] = new MapGridSlot();
            }
        }
    }

    public bool IsSlotAvailable(Vector3 indexPos)
    {
        return GetSlot(indexPos).IsAvailable;
    }

    public void SetGameObject(Vector3 indexPos, IFactoryItem factoryItem)
    {
        GetSlot(indexPos).SetFactoryItem(factoryItem);
    }

    private MapGridSlot GetSlot(Vector3 indexPos)
    {
        var layerSlots = mapGridSlots[(int)indexPos.y];
        return layerSlots[(int)indexPos.x, (int)indexPos.z];
    }

    public void SetSlotFlashing(Vector3 indexPos, bool isSlotAvailable)
    {
        GetSlot(indexPos).SetFlashing(isSlotAvailable);
    }
}
