namespace OrderTrackPro.Infrastructure.Configuration;

public class EmployeesConfiguration : IEntityTypeConfiguration<Employees>
{
    public void Configure(EntityTypeBuilder<Employees> builder)
    {
        builder.HasKey(e => e.EmployeeId);
        builder.ToTable("Employees");
        builder.HasIndex(e => e.LastName).HasDatabaseName("LastName");
        builder.HasIndex(e => e.PostalCode).HasDatabaseName("PostalCode");

        builder.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
        builder.Property(e => e.Address).HasMaxLength(60);
        builder.Property(e => e.BirthDate).HasColumnType("datetime");
        builder.Property(e => e.City).HasMaxLength(15);
        builder.Property(e => e.Country).HasMaxLength(15);
        builder.Property(e => e.Extension).HasMaxLength(4);

        builder.Property(e => e.FirstName)
            .IsRequired()
            .HasMaxLength(10);

        builder.Property(e => e.HireDate).HasColumnType("datetime");
        builder.Property(e => e.HomePhone).HasMaxLength(24);

        builder.Property(e => e.LastName)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(e => e.Photo).HasColumnType("image");
        builder.Property(e => e.PhotoPath).HasMaxLength(255);
        builder.Property(e => e.PostalCode).HasMaxLength(10);
        builder.Property(e => e.Region).HasMaxLength(15);
        builder.Property(e => e.Title).HasMaxLength(30);
        builder.Property(e => e.TitleOfCourtesy).HasMaxLength(25);

        builder.HasOne(e => e.ReportsToNavigation)
            .WithMany(e => e.InverseReportsToNavigation)
            .HasForeignKey(e => e.ReportsTo)
            .HasConstraintName("FK_Employees_Employees");

        builder.HasMany(e => e.Territories)
            .WithMany(t => t.Employees)
            .UsingEntity<Dictionary<string, object>>(
                "EmployeeTerritory",
                right => right.HasOne<Territories>()
                    .WithMany()
                    .HasForeignKey("TerritoryId")
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeTerritories_Territories"),
                left => left.HasOne<Employees>()
                    .WithMany()
                    .HasForeignKey("EmployeeId")
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeTerritories_Employees"),
                join =>
                {
                    join.HasKey("EmployeeId", "TerritoryId").IsClustered(false);
                    join.ToTable("EmployeeTerritories");

                    join.IndexerProperty<int>("EmployeeId").HasColumnName("EmployeeID");
                    join.IndexerProperty<string>("TerritoryId")
                        .HasMaxLength(20)
                        .HasColumnName("TerritoryID");
                });
    }
}
