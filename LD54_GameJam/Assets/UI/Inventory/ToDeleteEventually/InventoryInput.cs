using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryInput : MonoBehaviour
{
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Inventory.Instance.AddItem("cuivre");
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            Inventory.Instance.AddItem("fer");
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            Inventory.Instance.AddItem("plate cuivre");
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            Inventory.Instance.AddItem("plate fer");
        }
    }
}
