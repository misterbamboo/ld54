using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extractor : MonoBehaviour
{
    [SerializeField] private GameObject spawnPosition;
    [SerializeField] private GameObject prefabRessource;

    [SerializeField] private int maxStock;
    [SerializeField] private int currentStock;

    [SerializeField] private float productionInterval;
    [SerializeField] private float outputInterval;

    [SerializeField] private int productionRate;

    private float _productionTimer;
    private float _outputTimer;
    
    private void Start()
    {
        currentStock = 0;
        StartCoroutine(SpawnObject());
    }

    private void Update()
    {
        _productionTimer += Time.deltaTime;
        _outputTimer += Time.deltaTime;

        if (_productionTimer < productionInterval && _outputTimer < outputInterval) return;

        if (_productionTimer >= productionInterval)
        {
            ProduceResource();
            _productionTimer = 0;
        }

        if (_outputTimer >= outputInterval)
        {
            StartCoroutine(SpawnObject());
            _outputTimer = 0;
        }
    }

    // coroutine spawn object at interval
    private IEnumerator SpawnObject()
    {
        if (currentStock <= 0) yield break;
        
        Instantiate(prefabRessource, spawnPosition.transform.position, Quaternion.identity);
        currentStock -= 1;
        yield return new WaitForSeconds(outputInterval);
    }

    private void ProduceResource()
    {
        var stockDelta = currentStock + productionRate <= maxStock 
            ? productionRate : maxStock - currentStock;

        currentStock += stockDelta;
    }
}
