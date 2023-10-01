using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RessourceMovement : MonoBehaviour
{
    private GameObject target;

    [SerializeField]
    private float speed = 1f;

    public void SetTarget(GameObject gameObject)
    {
        target = gameObject;
    }

    public void Update()
    {
        // move to target with speed
        if (target != null)
        {
            var direction = target.transform.position - transform.position;
            var distance = direction.magnitude;
            var movement = direction.normalized * speed * Time.deltaTime;
            if (movement.magnitude > distance)
            {
                movement = direction;
            }
            transform.position += movement;
        }
    }
}
