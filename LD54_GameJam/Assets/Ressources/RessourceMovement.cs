using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RessourceMovement : MonoBehaviour
{
    private GameObject target;

    public void SetTarget(GameObject gameObject)
    {
        target = gameObject;
    }

    public void Update()
    {
        // move to target
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 0.1f);
        }
    }
}
