
namespace OrderTrackPro.Infrastructure.Configuration;
public class CustomersConfiguration : IEntityTypeConfiguration<Customers>
{
    public void Configure(EntityTypeBuilder<Customers> builder)
    {
        builder.ToTable("Customers");

        builder.HasKey(e => e.CustomerId);

        
        builder.HasIndex(e => e.City).HasDatabaseName("City");
        builder.HasIndex(e => e.CompanyName).HasDatabaseName("CompanyName");
        builder.HasIndex(e => e.PostalCode).HasDatabaseName("PostalCode");
        builder.HasIndex(e => e.Region).HasDatabaseName("Region");

        
        builder.Property(e => e.CustomerId)
            .HasColumnName("CustomerID")
            .HasMaxLength(5)
            .IsFixedLength();

        builder.Property(e => e.Address).HasMaxLength(60);
        builder.Property(e => e.City).HasMaxLength(15);

        builder.Property(e => e.CompanyName)
            .IsRequired()
            .HasMaxLength(40);

        builder.Property(e => e.ContactName).HasMaxLength(30);
        builder.Property(e => e.ContactTitle).HasMaxLength(30);
        builder.Property(e => e.Country).HasMaxLength(15);
        builder.Property(e => e.Fax).HasMaxLength(24);
        builder.Property(e => e.Phone).HasMaxLength(24);
        builder.Property(e => e.PostalCode).HasMaxLength(10);
        builder.Property(e => e.Region).HasMaxLength(15);

       
        builder.HasMany(c => c.CustomerTypes)
            .WithMany(d => d.Customers)
            .UsingEntity<Dictionary<string, object>>(
                "CustomerCustomerDemo",
                r => r.HasOne<CustomerDemographics>()
                      .WithMany()
                      .HasForeignKey("CustomerTypeId")
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("FK_CustomerCustomerDemo"),
                l => l.HasOne<Customers>()
                      .WithMany()
                      .HasForeignKey("CustomerId")
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("FK_CustomerCustomerDemo_Customers"),
                j =>
                {
                    j.HasKey("CustomerId", "CustomerTypeId").IsClustered(false);
                    j.ToTable("CustomerCustomerDemo");

                    j.IndexerProperty<string>("CustomerId")
                        .HasColumnName("CustomerID")
                        .HasMaxLength(5)
                        .IsFixedLength();

                    j.IndexerProperty<string>("CustomerTypeId")
                        .HasColumnName("CustomerTypeID")
                        .HasMaxLength(10)
                        .IsFixedLength();
                });
    }
}
