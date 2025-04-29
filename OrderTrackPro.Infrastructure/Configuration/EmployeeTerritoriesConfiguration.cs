namespace OrderTrackPro.Infrastructure.Configuration;


public class EmployeeTerritoryConfiguration : IEntityTypeConfiguration<EmployeeTerritories>
{
    public void Configure(EntityTypeBuilder<EmployeeTerritories> builder)
    {
        
        builder.HasKey(et => new { et.EmployeeId, et.TerritoryId }).IsClustered(false);

       
        builder.Property(et => et.EmployeeId).HasColumnName("EmployeeID");
        builder.Property(et => et.TerritoryId)
            .HasMaxLength(20)
            .HasColumnName("TerritoryID");

        
    }
}


