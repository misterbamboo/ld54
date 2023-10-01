using System;
using UnityEngine;

public class FactoryItem : MonoBehaviour, IFactoryItem
{
    [SerializeField] Vector3[] TakenSpaces;

    private bool isPlaced = false;

    public void SetPlaced(bool value)
    {
        isPlaced = value;
    }

    public bool IsPlaced => isPlaced;

    public void SetFlashing(bool flashing)
    {
        var color = flashing ? Color.red : Color.black;
        //mr.material.SetColor("_Flash_Color", color);
    }

    public Vector3[] GetTakenSpaces()
    {
        if (TakenSpaces == null || TakenSpaces.Length == 0)
        {
            return new Vector3[] { Vector3.zero };
        }

        return TakenSpaces;
    }
}
