using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        print("OnTriggerEnter");
    }
}
