using Microsoft.EntityFrameworkCore;

namespace OrderManagement.Infrastructure.Data;

public static class DatabaseInitializer
{
    public static void Initialize(OrderManagementDbContext db)
    {
        db.Database.EnsureCreated();

        // Поддерживает уже существующий SQLite-файл после добавления User в лабораторной работе №2.
        db.Database.ExecuteSqlRaw("""
            CREATE TABLE IF NOT EXISTS "Users" (
                "Id" TEXT NOT NULL CONSTRAINT "PK_Users" PRIMARY KEY,
                "Login" TEXT NOT NULL,
                "PassHash" TEXT NOT NULL
            );
            """);
        db.Database.ExecuteSqlRaw("""
            CREATE UNIQUE INDEX IF NOT EXISTS "IX_Users_Login" ON "Users" ("Login");
            """);
    }
}
