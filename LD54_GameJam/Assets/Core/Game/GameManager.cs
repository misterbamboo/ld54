using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Transform MapContainer;

    [SerializeField] FactoryItem RedRessourceVeinPrefab;
    [SerializeField] FactoryItem YellowRessourceVeinPrefab;
    [SerializeField] FactoryItem BlueRessourceVeinPrefab;

    void Start()
    {
        // create first layer at index 0
        MapGridController.Instance.MapGrid.AddLayersUntils(0);
        AddRedVein();
    }

    private void AddRedVein()
    {
        var redRessourceVein = Instantiate(RedRessourceVeinPrefab, MapContainer);
        redRessourceVein.transform.position = new Vector3(0, 0, 0);
        MapGridController.Instance.MapGrid.SetGameObject(redRessourceVein.transform.position.ToIndexPos(), redRessourceVein);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
