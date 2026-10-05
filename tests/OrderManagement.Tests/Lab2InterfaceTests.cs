using OrderManagement.Application.Interfaces;

namespace OrderManagement.Tests;

public sealed class Lab2InterfaceTests
{
    [Fact]
    public void Point_moves_through_interface()
    {
        IMovable point = new Point(0, 0);

        point.Move(5, 7);

        var movedPoint = Assert.IsType<Point>(point);
        Assert.Equal(5, movedPoint.X);
        Assert.Equal(7, movedPoint.Y);
    }

    [Fact]
    public void Shape_interface_returns_area_and_perimeter()
    {
        IShape rectangle = new Rectangle(4, 3);

        Assert.Equal(12, rectangle.GetArea());
        Assert.Equal(14, rectangle.GetPerimeter());
    }

    [Fact]
    public void Payment_is_processed_polymorphically()
    {
        var result = PaymentProcessor.ProcessPayment(new CreditCard(), 100m);

        Assert.Contains("100", result);
        Assert.Contains("картой", result);
    }
}
