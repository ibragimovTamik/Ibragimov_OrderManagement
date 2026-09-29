using Microsoft.EntityFrameworkCore;
using OrderManagement.Domain.Entities;

namespace OrderManagement.Infrastructure.Data;

/// <summary>Добавляет небольшой набор данных для демонстрации проекта.</summary>
public static class DatabaseSeeder
{
    public static void Seed(OrderManagementDbContext db)
    {
        if (db.Products.Any())
            return;

        var category = new Category("Электроника");
        var headphones = new Product("Беспроводные наушники", 3990m, category.Id);
        var keyboard = new Product("Клавиатура", 2490m, category.Id);
        var customer = new Customer("Иван Иванов", "ivan@example.ru", "+7 (900) 123-45-67");
        var warehouse = new Warehouse("Основной склад", "Москва, ул. Центральная, 1");
        var employee = new Employee("Петров Пётр", "Менеджер по заказам");
        var headphonesStock = new Inventory(warehouse.Id, headphones.Id, 12);
        var keyboardStock = new Inventory(warehouse.Id, keyboard.Id, 7);

        db.AddRange(
            category,
            headphones,
            keyboard,
            customer,
            warehouse,
            employee,
            headphonesStock,
            keyboardStock);
        db.SaveChanges();

        Console.WriteLine("Демонстрационные данные добавлены в базу.");
        Console.WriteLine($"Клиент для теста: {customer.Id}");
        Console.WriteLine($"Товар для теста: {headphones.Id}");
    }
}
