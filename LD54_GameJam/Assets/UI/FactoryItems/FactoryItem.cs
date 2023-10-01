using UnityEngine;

public class FactoryItem : MonoBehaviour, IFactoryItem
{
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
}
