using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    [SerializeField]
    GameObject target;

    public void SetRessourceTarget(RessourceMovement ressourceMovement)
    {
        ressourceMovement.SetTarget(target);
    }
}
