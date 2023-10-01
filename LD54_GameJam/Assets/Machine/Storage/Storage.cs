using UnityEngine;

public class Storage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var ressource = other.GetComponent<RessourceMovement>();
        if (ressource != null)
        {
            Destroy(ressource.gameObject);
            Inventory.Instance.AddItem("red");
        }
    }
}
