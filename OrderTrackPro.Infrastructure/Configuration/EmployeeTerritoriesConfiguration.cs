namespace OrderTrackPro.Infrastructure.Configuration;


public class EmployeeTerritoryConfiguration : IEntityTypeConfiguration<EmployeeTerritories>
{
    public void Configure(EntityTypeBuilder<EmployeeTerritories> builder)
    {
        // Clave primaria compuesta
        builder.HasKey(et => new { et.EmployeeId, et.TerritoryId }).IsClustered(false);

        // Configuración de las propiedades
        builder.Property(et => et.EmployeeId).HasColumnName("EmployeeID");
        builder.Property(et => et.TerritoryId)
            .HasMaxLength(20)
            .HasColumnName("TerritoryID");

        // Configuración de relaciones si es necesario, como las claves foráneas
        // Si tienes relaciones con otras entidades, añádelas aquí
        // Ejemplo:
        // builder.HasOne(et => et.Employee)
        //     .WithMany(e => e.EmployeeTerritories)
        //     .HasForeignKey(et => et.EmployeeId)
        //     .HasConstraintName("FK_EmployeeTerritories_Employees");

        // builder.HasOne(et => et.Territory)
        //     .WithMany(t => t.EmployeeTerritories)
        //     .HasForeignKey(et => et.TerritoryId)
        //     .HasConstraintName("FK_EmployeeTerritories_Territories");
    }
}


