using UnityEngine;

public class BuildTester : MonoBehaviour
{
    [SerializeField] private FactoryItem factoryItemPrefab;

    bool spawn = false;

    private void Start()
    {
        BuildModeController.Instance.OnFactoryItemPlaced += Instance_OnFactoryItemPlaced;
    }

    private void Instance_OnFactoryItemPlaced()
    {
        if (spawn)
        {
            BuildModeController.Instance.ActivateBuildMode(factoryItemPrefab);
        }
    }

    void Update()
    {
        if (!spawn)
        {
            spawn = true;
            BuildModeController.Instance.ActivateBuildMode(factoryItemPrefab);
        }
    }
}
