using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extractor : MonoBehaviour
{
    [SerializeField] private GameObject spawnPosition;
    [SerializeField] private GameObject prefabRessource;

    [SerializeField] private int maxStock = 20;
    [SerializeField] private int currentStock = 0;

    [SerializeField] private float productionInterval = 1.0f;
    [SerializeField] private float outputInterval = 1.0f;

    [SerializeField] private int productionRate;

    [SerializeField] private Animator animator;
    
    private float _productionTimer;
    private float _outputTimer;

    
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

    private IEnumerator SpawnObject()
    {        
        if (currentStock > 0)
        {
            animator.SetTrigger("Output");
            Instantiate(prefabRessource, spawnPosition.transform.position, Quaternion.identity);
            currentStock -= 1;
            yield return new WaitForSeconds(outputInterval);
        }
    }

    private void ProduceResource()
    {
        var stockDelta = currentStock + productionRate <= maxStock 
            ? productionRate : maxStock - currentStock;

        if (stockDelta > 0)
        { 
            animator.SetTrigger("Produce");
        }

        currentStock += stockDelta;
    }
}
