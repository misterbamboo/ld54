public class MapGridSlot
{
    public bool IsAvailable => FactoryItem == null;

    public IFactoryItem FactoryItem { get; private set; }

    public void SetFactoryItem(IFactoryItem factoryItem)
    {
        FactoryItem = factoryItem;
    }

    public void SetFlashing(bool isSlotAvailable)
    {
        if (FactoryItem == null) return;
        FactoryItem.SetFlashing(isSlotAvailable);
    }
}
