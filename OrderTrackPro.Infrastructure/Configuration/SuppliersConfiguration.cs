﻿namespace OrderTrackPro.Infrastructure.Configuration;



public class SuppliersConfiguration : IEntityTypeConfiguration<Suppliers>
{
    public void Configure(EntityTypeBuilder<Suppliers> builder)
    {
        builder.HasKey(e => e.SupplierId);

        builder.HasIndex(e => e.CompanyName)
               .HasDatabaseName("CompanyName");

        builder.HasIndex(e => e.PostalCode)
               .HasDatabaseName("PostalCode");

        builder.Property(e => e.SupplierId)
               .HasColumnName("SupplierID");

        builder.Property(e => e.Address)
               .HasMaxLength(60);

        builder.Property(e => e.City)
               .HasMaxLength(15);

        builder.Property(e => e.CompanyName)
               .IsRequired()
               .HasMaxLength(40);

        builder.Property(e => e.ContactName)
               .HasMaxLength(30);

        builder.Property(e => e.ContactTitle)
               .HasMaxLength(30);

        builder.Property(e => e.Country)
               .HasMaxLength(15);

        builder.Property(e => e.Fax)
               .HasMaxLength(24);

        builder.Property(e => e.Phone)
               .HasMaxLength(24);

        builder.Property(e => e.PostalCode)
               .HasMaxLength(10);

        builder.Property(e => e.Region)
               .HasMaxLength(15);
    }
}
