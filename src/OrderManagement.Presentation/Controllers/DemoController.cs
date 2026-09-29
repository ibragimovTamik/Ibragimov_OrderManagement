using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderManagement.Infrastructure.Data;

namespace OrderManagement.Presentation.Controllers;

[ApiController]
[Route("api/demo")]
public sealed class DemoController(OrderManagementDbContext db) : ControllerBase
{
    /// <summary>Показать демонстрационные данные для проверки API.</summary>
    /// <remarks>
    /// Скопируйте customerId и productId в POST /api/orders.
    /// Пример тела запроса: { "customerId": "...", "items": [{ "productId": "...", "quantity": 1 }], "paymentMethod": "Банковская карта", "deliveryAddress": "Москва, ул. Центральная, 1" }
    /// </remarks>
    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        var customers = await db.Customers
            .AsNoTracking()
            .Select(x => new { x.Id, x.FullName, x.Email, x.Phone })
            .ToListAsync(cancellationToken);

        var products = await db.Products
            .AsNoTracking()
            .Select(x => new { x.Id, x.Name, x.Price, x.CategoryId })
            .ToListAsync(cancellationToken);

        return Ok(new
        {
            message = "Используйте эти идентификаторы для создания заказа через POST /api/orders.",
            customers,
            products
        });
    }
}
