# OrderManagement

Учебный проект для лабораторных работ №1–2 по теме системы управления заказами интернет-магазина.

Проект моделирует систему управления заказами интернет-магазина и разделен по слоям:

- `OrderManagement.Domain` — сущности и правила предметной области.
- `OrderManagement.Application` — сценарии приложения, DTO и интерфейсы.
- `OrderManagement.Infrastructure` — Entity Framework Core, SQLite и репозитории.
- `OrderManagement.Presentation` — ASP.NET Core Web API.
- `OrderManagement.Tests` — модульные тесты доменной логики.

В лабораторной работе №2 дополнительно реализованы интерфейсы C#, обобщённый репозиторий, Unit of Work и CRUD API пользователей с передачей данных в JSON.

## Запуск в Visual Studio

1. Установить Visual Studio 2022 с рабочей нагрузкой **ASP.NET и разработка веб-приложений** и .NET 8 SDK.
2. Открыть `OrderManagement.sln`.
3. Выбрать `OrderManagement.Presentation` запускаемым проектом.
4. Нажать `F5`. Swagger откроется по адресу из профиля запуска.
5. Для запуска тестов открыть окно **Обозреватель тестов** и выполнить все тесты.

Дополнительные пакеты устанавливать не нужно: проект использует уже подключённые EF Core SQLite, Swagger и xUnit.

## API

- `GET /api/orders/{id}` — получить заказ.
- `POST /api/orders` — создать заказ.
- `GET /api/demo` — получить демонстрационные данные для проверки заказа.
- `POST /api/user` — создать пользователя.
- `GET /api/user/{id}` — получить пользователя.
- `PUT /api/user/{id}` — изменить пользователя.
- `DELETE /api/user/{id}` — удалить пользователя.

Для пользователя формат JSON такой:

```json
{
  "login": "student_01",
  "passHash": "hash_of_password"
}
```

Поле `passHash` должно содержать хеш пароля, а не открытый пароль. Логин проверяется на уникальность.

Пример тела POST-запроса:

```json
{
  "customerId": "00000000-0000-0000-0000-000000000001",
  "items": [
    {
      "productId": "00000000-0000-0000-0000-000000000002",
      "quantity": 2
    }
  ],
  "paymentMethod": "Карта",
  "deliveryAddress": "Москва, ул. Примерная, д. 1"
}
```

## GitHub

Локальный Git-репозиторий подготовлен. Для отправки в личный GitHub:

```bash
git remote add origin https://github.com/<ваш-логин>/OrderManagement.git
git branch -M main
git push -u origin main
```
