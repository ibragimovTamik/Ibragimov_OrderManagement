using Microsoft.EntityFrameworkCore;
using OrderManagement.Domain.Entities;

namespace OrderManagement.Infrastructure.Data;

public sealed class OrderManagementDbContext(DbContextOptions<OrderManagementDbContext> options)
    : DbContext(options)
{
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderItem> OrderItems => Set<OrderItem>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Payment> Payments => Set<Payment>();
    public DbSet<Delivery> Deliveries => Set<Delivery>();
    public DbSet<Warehouse> Warehouses => Set<Warehouse>();
    public DbSet<Inventory> Inventory => Set<Inventory>();
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>().HasKey(x => x.Id);
        modelBuilder.Entity<Customer>().Property(x => x.FullName).HasMaxLength(200).IsRequired();
        modelBuilder.Entity<Customer>().HasMany(x => x.Orders).WithOne(x => x.Customer).HasForeignKey(x => x.CustomerId);

        modelBuilder.Entity<Category>().HasKey(x => x.Id);
        modelBuilder.Entity<Category>().HasMany(x => x.Products).WithOne(x => x.Category).HasForeignKey(x => x.CategoryId);

        modelBuilder.Entity<Product>().HasKey(x => x.Id);
        modelBuilder.Entity<Product>().Property(x => x.Price).HasPrecision(18, 2);

        modelBuilder.Entity<Order>().HasKey(x => x.Id);
        modelBuilder.Entity<Order>().HasMany(x => x.Items).WithOne(x => x.Order).HasForeignKey(x => x.OrderId);
        modelBuilder.Entity<Order>().HasOne(x => x.Payment).WithOne(x => x.Order).HasForeignKey<Payment>(x => x.OrderId);
        modelBuilder.Entity<Order>().HasOne(x => x.Delivery).WithOne(x => x.Order).HasForeignKey<Delivery>(x => x.OrderId);
        modelBuilder.Entity<Employee>().HasMany(x => x.Orders).WithOne(x => x.Employee).HasForeignKey(x => x.EmployeeId);

        modelBuilder.Entity<OrderItem>().HasKey(x => x.Id);
        modelBuilder.Entity<OrderItem>().Property(x => x.UnitPrice).HasPrecision(18, 2);

        modelBuilder.Entity<Warehouse>().HasKey(x => x.Id);
        modelBuilder.Entity<Warehouse>().HasMany(x => x.Inventory).WithOne(x => x.Warehouse).HasForeignKey(x => x.WarehouseId);
        modelBuilder.Entity<Inventory>().HasKey(x => x.Id);
        modelBuilder.Entity<Inventory>().HasOne(x => x.Product).WithMany(x => x.Inventory).HasForeignKey(x => x.ProductId);

        modelBuilder.Entity<User>().HasKey(x => x.Id);
        modelBuilder.Entity<User>().Property(x => x.Login).HasMaxLength(100).IsRequired();
        modelBuilder.Entity<User>().Property(x => x.PassHash).HasMaxLength(500).IsRequired();
        modelBuilder.Entity<User>().HasIndex(x => x.Login).IsUnique();
    }
}
