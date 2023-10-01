using System;
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
        var slot = GetSlot(indexPos);
        return slot == null ? false : slot.IsAvailable;
    }

    public void SetGameObject(Vector3 indexPos, IFactoryItem factoryItem)
    {
        var slot = GetSlot(indexPos);
        if (slot != null)
        {
            slot.SetFactoryItem(factoryItem);
        }
    }

    private MapGridSlot? GetSlot(Vector3 indexPos)
    {
        int y = (int)indexPos.y;
        int x = (int)indexPos.x;
        int z = (int)indexPos.z;

        if (y < 0 || y >= mapGridSlots.Count) return null;
        var layerSlots = mapGridSlots[y];

        if (x < 0 || x >= layerSlots.GetLength(0)) return null;
        if (z < 0 || z >= layerSlots.GetLength(1)) return null;

        return layerSlots[x, z];
    }

    public void SetSlotFlashing(Vector3 indexPos, bool isSlotAvailable)
    {
        var slot = GetSlot(indexPos);
        if (slot != null)
        {
            slot.SetFlashing(isSlotAvailable);
        }
    }
}
