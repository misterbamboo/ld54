using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Smelter : MonoBehaviour
{
    public Extractor_OG[] extractors;
    
    public int maxInputStock;
    public int currentInputStock;    
    
    public int maxOutputStock;
    public int currentOutputStock;

    public float inputInterval;
    public float outputInterval;
    
    public int consumptionRate;
    public int productionRate;

    private float _outputTimer;
    private float _inputTimer;
    
    // Start is called before the first frame update
    private void Start()
    {
        currentInputStock = 0; 
        currentOutputStock = 0;

        _inputTimer = 0;
        _outputTimer = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        _outputTimer += Time.deltaTime;
        _inputTimer += Time.deltaTime;

        if (!(_outputTimer > outputInterval || _inputTimer > inputInterval)) return;
        
        if (_inputTimer > inputInterval)
        {
            PullResource();
        }

        if (!(_outputTimer > outputInterval) || currentOutputStock >= maxOutputStock) return;
        
        ProduceResource();
    }

    private void ProduceResource()
    {
        var newValue = currentOutputStock + productionRate;
        
        if (!(currentInputStock >= consumptionRate && newValue <= maxOutputStock)) return;
        
        currentOutputStock += productionRate;
        currentInputStock -= consumptionRate;

        _outputTimer = 0;
    }

    private void PullResource()
    {
        _inputTimer = 0;
        
        var pulledResourceTotalAmount = 0;
        var availableInputStockSpace = maxInputStock - currentInputStock;

        foreach (var extractor in extractors)
        {
            // var resourceDelta = availableInputStockSpace >= inputRate
            //     ? inputRate - pulledResourceTotalAmount
            //     : availableInputStockSpace - pulledResourceTotalAmount;
            
            // var receivedResources = extractor.SendResources(resourceDelta);

            // pulledResourceTotalAmount += receivedResources;

            // var timestamp = DateTime.Now;
            // Debug.Log($"{timestamp:HH:mm:ss.fff} - {transform.name} pulled {receivedResources} mats from {extractor.transform.name}, total pulled mats is {pulledResourceTotalAmount} : {extractor.currentStock} left in extractor\n");
            
            // if (pulledResourceTotalAmount == inputRate) break;
        }
        
        if (pulledResourceTotalAmount <= 0) return;
        
        currentInputStock += pulledResourceTotalAmount;
    }
}