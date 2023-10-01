using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RessourceMovement : MonoBehaviour
{
    private GameObject target = null;

    private bool shouldMove = false;

    [SerializeField]
    private float speed = 1f;

    public void SetTarget(GameObject gameObject)
    {
        shouldMove = true;
        target = gameObject;
    }

    public void Update()
    {
        if (target == null || !shouldMove) 
            return;
        
        var direction = target.transform.position - transform.position;
        var distance = direction.magnitude;
        var movement = direction.normalized * (speed * Time.deltaTime);
        if (movement.magnitude > distance)
        {
            movement = direction;
        }
        transform.position += movement;
    }
}
