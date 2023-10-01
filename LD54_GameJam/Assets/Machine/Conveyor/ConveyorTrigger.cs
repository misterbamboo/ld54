using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ConveyorTrigger : MonoBehaviour
{
    [SerializeField]
    Conveyor conveyor;

    FactoryItem factoryItem = null;

    private void Awake()
    {
        factoryItem = GetComponentInParent<FactoryItem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        var ressourceMovement = other.GetComponent<RessourceMovement>();
        if (ressourceMovement != null && factoryItem.IsPlaced)
        {
            conveyor.SetRessourceTarget(ressourceMovement);
        }
    }
}
