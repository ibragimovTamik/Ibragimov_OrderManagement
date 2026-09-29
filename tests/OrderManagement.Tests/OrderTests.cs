using OrderManagement.Domain.Entities;
using OrderManagement.Domain.Enums;

namespace OrderManagement.Tests;

public sealed class OrderTests
{
    [Fact]
    public void New_order_can_be_confirmed_and_calculates_total()
    {
        var order = new Order(Guid.NewGuid());
        order.AddItem(Guid.NewGuid(), 120m, 2);
        order.AddItem(Guid.NewGuid(), 80m, 1);

        order.Confirm();

        Assert.Equal(OrderStatus.Confirmed, order.Status);
        Assert.Equal(320m, order.TotalAmount);
        Assert.Equal(2, order.Items.Count);
    }

    [Fact]
    public void Negative_quantity_is_rejected()
    {
        var order = new Order(Guid.NewGuid());

        Assert.Throws<ArgumentOutOfRangeException>(() =>
            order.AddItem(Guid.NewGuid(), 100m, 0));
    }
}
