using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField] private GameObject baseElevator;
    [SerializeField] private GameObject levelElevator;

    [SerializeField] private bool isBase;

    private void OnDrawGizmos()
    {
        DrawBaseOrLevel();
    }

    void Update()
    {
        DrawBaseOrLevel();
    }

    private void DrawBaseOrLevel()
    {
        if (isBase != baseElevator.activeInHierarchy)
        {
            baseElevator.SetActive(isBase);
            levelElevator.SetActive(!isBase);
        }
    }

    public void ChangeIsBase(bool isBase)
    {
        this.isBase = isBase;
    }
}
