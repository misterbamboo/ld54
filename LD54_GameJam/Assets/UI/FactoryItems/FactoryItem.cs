using UnityEngine;

public class FactoryItem : MonoBehaviour, IFactoryItem
{
    public void SetFlashing(bool flashing)
    {
        var color = flashing ? Color.red : Color.black;
        //mr.material.SetColor("_Flash_Color", color);
    }
}
