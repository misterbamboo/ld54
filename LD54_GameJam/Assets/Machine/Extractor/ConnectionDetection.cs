using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionDetection : MonoBehaviour
{
    private bool isConnected = false;

    public bool IsConnected => isConnected;

    GameObject collider = null;

    void Update()
    {
        if (collider != null)
        {
            var factoryItem = collider.GetComponentInParent<FactoryItem>();
            if (factoryItem != null && factoryItem.IsPlaced)
            {
                isConnected = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var conveyor = other.GetComponentInParent<Conveyor>();
        var factoryItem = other.GetComponentInParent<FactoryItem>();
        if (conveyor != null)
        {
            collider = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var conveyor = other.GetComponentInParent<Conveyor>();
        if (conveyor != null)
        {
            collider = null;
            isConnected = false;
        }
    }
}
