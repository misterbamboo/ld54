public class InventoryResource
{
    public string Name { get; set; }
    public double Flow { get; set; }

    public InventoryResource(string name, double flow)
    {
        Name = name;
        Flow = flow;
    }
}