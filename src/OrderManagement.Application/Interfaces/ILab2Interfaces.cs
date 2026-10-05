namespace OrderManagement.Application.Interfaces;

public interface IMovable
{
    void Move(int x, int y);
}

public sealed class Point : IMovable
{
    public Point(int x, int y) => (X, Y) = (x, y);
    public int X { get; private set; }
    public int Y { get; private set; }
    public void Move(int x, int y) => (X, Y) = (x, y);
}

public interface IDrawable
{
    string Draw();
}

public interface IShape : IDrawable
{
    double GetArea();
    double GetPerimeter();
}

public interface I3DShape : IShape
{
    double GetVolume();
}

public sealed class Circle(double radius) : IShape
{
    public double Radius { get; } = radius;
    public double GetArea() => Math.PI * Radius * Radius;
    public double GetPerimeter() => 2 * Math.PI * Radius;
    public string Draw() => $"Окружность радиусом {Radius}";
}

public sealed class Rectangle(double width, double height) : IShape
{
    public double Width { get; } = width;
    public double Height { get; } = height;
    public double GetArea() => Width * Height;
    public double GetPerimeter() => 2 * (Width + Height);
    public string Draw() => $"Прямоугольник {Width} x {Height}";
}

public sealed class Cube(double side) : I3DShape
{
    public double Side { get; } = side;
    public double GetArea() => 6 * Side * Side;
    public double GetPerimeter() => 12 * Side;
    public double GetVolume() => Side * Side * Side;
    public string Draw() => $"Куб со стороной {Side}";
}

public static class ShapePrinter
{
    public static IReadOnlyCollection<string> DrawAll(IEnumerable<IDrawable> shapes) =>
        shapes.Select(shape => shape.Draw()).ToArray();

    public static string PrintShapeInfo(IShape shape) =>
        $"Площадь: {shape.GetArea():F2}; периметр: {shape.GetPerimeter():F2}";
}

// Часть задания про разделение «толстого» интерфейса.
public interface IDevice
{
    void Print();
    void Scan();
    void Fax();
}

public interface IPrinter { void Print(); }
public interface IScanner { void Scan(); }
public interface IFax { void Fax(); }

public sealed class Printer : IDevice, IPrinter, IScanner
{
    public void Print() { }
    public void Scan() { }
    public void Fax() { }
}

public sealed class Scanner : IDevice, IScanner
{
    public void Print() { }
    public void Scan() { }
    public void Fax() { }
}

public sealed class MultifunctionDevice : IPrinter, IScanner, IFax
{
    public void Print() { }
    public void Scan() { }
    public void Fax() { }
}

public interface IPayable
{
    string Pay(decimal amount);
}

public sealed class CreditCard : IPayable
{
    public string Pay(decimal amount) => $"Оплата картой: {amount:0.00} руб.";
}

public sealed class Cash : IPayable
{
    public string Pay(decimal amount) => $"Оплата наличными: {amount:0.00} руб.";
}

public static class PaymentProcessor
{
    public static string ProcessPayment(IPayable method, decimal amount) => method.Pay(amount);
}

public interface ILogger
{
    void Log(string message);
}

public sealed class ConsoleLogger : ILogger
{
    public void Log(string message) => Console.WriteLine(message);
}

public sealed class FileLogger(string filePath) : ILogger
{
    public void Log(string message) => File.AppendAllText(filePath, message + Environment.NewLine);
}

public static class WorkProcessor
{
    public static void DoWork(ILogger logger) => logger.Log("Работа выполнена.");
}
