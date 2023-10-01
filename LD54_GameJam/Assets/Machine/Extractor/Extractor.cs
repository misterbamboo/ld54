using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extractor : MonoBehaviour
{
    [SerializeField]
    float interval = 1.0f;

    public void Start()
    {
        StartCoroutine(SpawnObject());
    }

    // coroutine spawn object at interval
    IEnumerator SpawnObject()
    {
        yield return new WaitForSeconds(interval);

    }
}
