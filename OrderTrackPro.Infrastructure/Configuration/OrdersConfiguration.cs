namespace OrderTrackPro.Infrastructure.Configuration;


public class OrdersConfiguration : IEntityTypeConfiguration<Orders>
{
    public void Configure(EntityTypeBuilder<Orders> builder)
    {
        builder.HasIndex(e => e.CustomerId).HasDatabaseName("CustomerID");
        builder.HasIndex(e => e.CustomerId).HasDatabaseName("CustomersOrders");
        builder.HasIndex(e => e.EmployeeId).HasDatabaseName("EmployeeID");
        builder.HasIndex(e => e.EmployeeId).HasDatabaseName("EmployeesOrders");
        builder.HasIndex(e => e.OrderDate).HasDatabaseName("OrderDate");
        builder.HasIndex(e => e.ShipPostalCode).HasDatabaseName("ShipPostalCode");
        builder.HasIndex(e => e.ShippedDate).HasDatabaseName("ShippedDate");
        builder.HasIndex(e => e.ShipVia).HasDatabaseName("ShippersOrders");

        builder.Property(e => e.OrderId).HasColumnName("OrderID");

        builder.Property(e => e.CustomerId)
            .HasMaxLength(5)
            .IsFixedLength()
            .HasColumnName("CustomerID");

        builder.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

        builder.Property(e => e.Freight)
            .HasColumnType("money")
            .HasDefaultValue(0m);

        builder.Property(e => e.OrderDate).HasColumnType("datetime");
        builder.Property(e => e.RequiredDate).HasColumnType("datetime");
        builder.Property(e => e.ShippedDate).HasColumnType("datetime");

        builder.Property(e => e.ShipAddress).HasMaxLength(60);
        builder.Property(e => e.ShipCity).HasMaxLength(15);
        builder.Property(e => e.ShipCountry).HasMaxLength(15);
        builder.Property(e => e.ShipName).HasMaxLength(40);
        builder.Property(e => e.ShipPostalCode).HasMaxLength(10);
        builder.Property(e => e.ShipRegion).HasMaxLength(15);

        builder.HasOne(e => e.Customer)
            .WithMany(c => c.Orders)
            .HasForeignKey(e => e.CustomerId)
            .HasConstraintName("FK_Orders_Customers");

        builder.HasOne(e => e.Employee)
            .WithMany(emp => emp.Orders)
            .HasForeignKey(e => e.EmployeeId)
            .HasConstraintName("FK_Orders_Employees");

        builder.HasOne(e => e.ShipViaNavigation)
            .WithMany(s => s.Orders)
            .HasForeignKey(e => e.ShipVia)
            .HasConstraintName("FK_Orders_Shippers");
    }
}

