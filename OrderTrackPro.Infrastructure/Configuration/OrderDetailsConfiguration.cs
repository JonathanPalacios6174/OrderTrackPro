namespace OrderTrackPro.Infrastructure.Configuration;


  
public class OrderDetailsConfiguration : IEntityTypeConfiguration<OrderDetails>
{
    public void Configure(EntityTypeBuilder<OrderDetails> builder)
    {
        builder.HasKey(e => new { e.OrderId, e.ProductId })
            .HasName("PK_Order_Details");

        builder.ToTable("Order Details");

        builder.HasIndex(e => e.OrderId).HasDatabaseName("OrderID");
        builder.HasIndex(e => e.OrderId).HasDatabaseName("OrdersOrder_Details");
        builder.HasIndex(e => e.ProductId).HasDatabaseName("ProductID");
        builder.HasIndex(e => e.ProductId).HasDatabaseName("ProductsOrder_Details");

        builder.Property(e => e.OrderId).HasColumnName("OrderID");
        builder.Property(e => e.ProductId).HasColumnName("ProductID");

        builder.Property(e => e.Quantity)
            .HasDefaultValue((short)1);

        builder.Property(e => e.UnitPrice)
            .HasColumnType("money");

        builder.HasOne(d => d.Order)
            .WithMany(p => p.OrderDetails)
            .HasForeignKey(d => d.OrderId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Order_Details_Orders");

        builder.HasOne(d => d.Product)
            .WithMany(p => p.OrderDetails)
            .HasForeignKey(d => d.ProductId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Order_Details_Products");
    }
}
