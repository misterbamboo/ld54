using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class RowItem : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI nameTextMesh;

    [SerializeField]
    private TextMeshProUGUI qtyTextMesh;

    public void Init(string name)
    {
        nameTextMesh.text = name;
        UpdateQty(0);
    }

    public void UpdateQty(int value)
    {
        qtyTextMesh.text = value.ToString();
    }
}
