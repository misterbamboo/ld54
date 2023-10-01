using UnityEngine;

public class FactoryItem : MonoBehaviour, IFactoryItem
{
    [SerializeField] MeshRenderer mr;

    public void SetFlashing(bool flashing)
    {
        var color = flashing ? Color.red : Color.black;
        mr.material.SetColor("_Flash_Color", color);
    }
}
