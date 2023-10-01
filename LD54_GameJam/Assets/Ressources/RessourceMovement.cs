using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RessourceMovement : MonoBehaviour
{
    private GameObject target = null;

    [SerializeField]
    private float speed = 1f;

    private bool _istargetNotNull;

    private void Start()
    {
        _istargetNotNull = target != null;
    }

    public void SetTarget(GameObject gameObject)
    {
        target = gameObject;
    }

    public void Update()
    {
        if (!_istargetNotNull) return;
        
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
