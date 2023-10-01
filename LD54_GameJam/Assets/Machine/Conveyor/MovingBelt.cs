using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBelt : MonoBehaviour
{
    [SerializeField] Transform Belt1;
    [SerializeField] Transform Belt2;

    float time = 0;

    void Update()
    {
        time += Time.deltaTime;
        if (time > 1)
        {
            time -= 1;
        }

        var pos1 = Belt1.position;
        pos1.z = Mathf.Lerp(0, 1, time);
        Belt1.position = pos1;

        var pos2 = Belt2.position;
        pos2.z = Mathf.Lerp(-1, 0, time);
        Belt2.position = pos2;
    }
}
