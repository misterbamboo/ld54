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
        var ressourceMovement = other.GetComponent<RessourceMovement>();
        if (ressourceMovement != null)
        {
            conveyor.SetRessourceTarget(ressourceMovement);
        }
    }
}
