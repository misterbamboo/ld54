using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ConveyorTrigger : MonoBehaviour
{
    [SerializeField]
    Conveyor conveyor;

    private void OnTriggerEnter(Collider other)
    {
        print("OnTriggerEnter");
        var ressourceMovement = other.GetComponent<RessourceMovement>();
        if (ressourceMovement != null)
        {
            print("ressourceMovement");
            conveyor.SetRessourceTarget(ressourceMovement);
        }
    }
}
