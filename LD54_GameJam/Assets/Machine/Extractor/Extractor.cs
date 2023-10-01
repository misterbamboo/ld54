using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extractor : MonoBehaviour
{
    [SerializeField]
    float interval = 1.0f;

    [SerializeField]
    GameObject spawnPosition;

    [SerializeField]
    GameObject prefabRessource;

    public void Start()
    {
        StartCoroutine(SpawnObject());
    }

    // coroutine spawn object at interval
    IEnumerator SpawnObject()
    {
        Instantiate(prefabRessource, spawnPosition.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(interval);
        StartCoroutine(SpawnObject());
    }
}
