using UnityEngine;

public interface IFactoryItem
{
    Vector3[] GetTakenSpaces();

    void SetPlaced(bool value);

    void SetFlashing(bool flashing);
}
