using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionDetection : MonoBehaviour
{
    private bool isConnected = false;

    public bool IsConnected => isConnected;

    Conveyor savedConveyor = null;

    void Update()
    {
        if (savedConveyor != null)
        {
            var factoryItem = savedConveyor.GetComponentInParent<FactoryItem>();
            if (factoryItem != null && factoryItem.IsPlaced)
            {
                isConnected = true;
            }
            else if(isConnected)
            {
                isConnected = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (savedConveyor != null)
            return;

        var conveyor = other.GetComponentInParent<Conveyor>();
        if (conveyor == null)      
            return;

        var factoryItem = conveyor.GetComponentInParent<FactoryItem>();
        if (factoryItem == null && !factoryItem.IsPlaced)
            return;

        savedConveyor = conveyor;                           
    }

    private void OnTriggerExit(Collider other)
    {
        var conveyor = other.GetComponentInParent<Conveyor>();
        if (conveyor == null)
            return;
        
        savedConveyor = null;     
    }
}
