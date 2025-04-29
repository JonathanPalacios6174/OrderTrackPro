namespace OrderTrackPro.Infrastructure.Configuration;


public class ShippersConfiguration : IEntityTypeConfiguration<Shippers>
{
    public void Configure(EntityTypeBuilder<Shippers> builder)
    {
        builder.Property(e => e.ShipperId)
               .HasColumnName("ShipperID");

        builder.Property(e => e.CompanyName)
               .IsRequired()
               .HasMaxLength(40);

        builder.Property(e => e.Phone)
               .HasMaxLength(24);
    }
}
