# Архитектура проекта

## Зависимости проектов

```text
Presentation -> Application -> Domain
Presentation -> Infrastructure -> Application
Infrastructure -> Domain
Tests -> Domain
```

## Сущности

В модели используются сущности `Customer`, `Order`, `OrderItem`, `Product`, `Category`, `Payment`, `Delivery`, `Warehouse`, `Inventory` и `Employee`.

## Связи

- Один клиент оформляет много заказов: `Customer 1:N Order`.
- Один заказ содержит много позиций: `Order 1:N OrderItem`.
- Одна позиция относится к одному товару: `OrderItem N:1 Product`.
- Одна категория содержит много товаров: `Category 1:N Product`.
- У заказа одна оплата и одна доставка: `Order 1:1 Payment`, `Order 1:1 Delivery`.
- На одном складе хранится много остатков: `Warehouse 1:N Inventory`.
- Один товар может иметь остатки на разных складах: `Product 1:N Inventory`.
- Один сотрудник может обрабатывать много заказов: `Employee 1:N Order`.
