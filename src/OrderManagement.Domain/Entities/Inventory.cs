namespace OrderManagement.Domain.Entities;

public sealed class Inventory
{
    private Inventory() { }

    public Inventory(Guid warehouseId, Guid productId, int quantity)
    {
        Id = Guid.NewGuid();
        WarehouseId = warehouseId;
        ProductId = productId;
        Quantity = quantity;
    }

    public Guid Id { get; private set; }
    public Guid WarehouseId { get; private set; }
    public Warehouse? Warehouse { get; private set; }
    public Guid ProductId { get; private set; }
    public Product? Product { get; private set; }
    public int Quantity { get; private set; }
}
