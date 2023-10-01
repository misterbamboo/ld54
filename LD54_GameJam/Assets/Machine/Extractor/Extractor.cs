using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Extractor : MonoBehaviour
{
    [SerializeField] private GameObject prefabRessource;

    [SerializeField] private int maxStock = 20;
    [SerializeField] private int currentStock = 0;

    [SerializeField] private float productionInterval = 1.0f;
    [SerializeField] private float outputInterval = 1.0f;

    [SerializeField] private int productionRate;

    [SerializeField] private Animator animator;

    private List<ConnectionDetection> connectionDetections = new List<ConnectionDetection>();

    private float _productionTimer;
    private float _outputTimer;

    private void Awake()
    {
        connectionDetections = gameObject.gameObject.GetComponentsInChildren<ConnectionDetection>().ToList();
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
            SpawnObject();
            _outputTimer = 0;
        }
    }

    private void SpawnObject()
    {   
        var connectionDetectionConnecteds = connectionDetections.Where(c => c.IsConnected);
        if (connectionDetectionConnecteds.Count() > 0 && currentStock > 0)
        {
            animator.SetTrigger("Output");
            foreach (var connectionDetection in connectionDetectionConnecteds)
            {
                if (currentStock > 0)
                {
                    var spawnPoint = connectionDetection.GetComponentInParent<SpawnPoint>();
                    Instantiate(prefabRessource, spawnPoint.transform.position, Quaternion.identity);
                    currentStock -= 1;
                }
            }            
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
