using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionDetection : MonoBehaviour
{
    private bool isConnected = false;

    public bool IsConnected => isConnected;

    private void OnTriggerEnter(Collider other)
    {
        print("OnTriggerEnter");
        var conveyor = other.GetComponentInParent<Conveyor>();
        if (conveyor != null)
        {
            isConnected = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        print("OnTriggerExit");
        var conveyor = other.GetComponentInParent<Conveyor>();
        if (conveyor != null)
        {
            isConnected = false;
        }
    }
}
