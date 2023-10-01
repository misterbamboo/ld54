using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
public class Extractor : MonoBehaviour
{
    public int maxStock;
    public int currentStock;

    public float productionInterval;
    public float outputInterval;
    public int productionRate;

    public float outputRate;

    public float productionTimer;
    public float outputTimer;
    
    private InventoryResource _resourceOutput;
    
    // Start is called before the first frame update
    private void Start()
    {
        currentStock = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        productionTimer += Time.deltaTime;
        outputTimer += Time.deltaTime;

        if (productionTimer >= productionInterval)
        {
            ProduceResource();
            productionTimer = 0;
        }

        if (outputTimer >= outputInterval)
        {
            OutputToBelt();
            outputTimer = 0;
        }
    }

    // public int SendResources(int delta)
    // {
    //     var sentResources = currentStock > delta ? delta : currentStock > 0 ? currentStock : 0;
    //     
    //     if (sentResources > 0)
    //     {
    //         currentStock -= sentResources;
    //     }
    //
    //     return sentResources;
    // }

    private void ProduceResource()
    {
        currentStock += productionRate;
    }

    private void OutputToBelt()
    {
        currentStock -= 1;
    }
}
*/