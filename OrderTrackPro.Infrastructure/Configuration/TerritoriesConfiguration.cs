namespace OrderTrackPro.Infrastructure.Configuration;



public class TerritoriesConfiguration : IEntityTypeConfiguration<Territories>
{
    public void Configure(EntityTypeBuilder<Territories> builder)
    {
        builder.HasKey(e => e.TerritoryId)
               .IsClustered(false);

        builder.Property(e => e.TerritoryId)
               .HasMaxLength(20)
               .HasColumnName("TerritoryID");

        builder.Property(e => e.RegionId)
               .HasColumnName("RegionID");

        builder.Property(e => e.TerritoryDescription)
               .IsRequired()
               .HasMaxLength(50)
               .IsFixedLength();

        builder.HasOne(d => d.Region)
               .WithMany(p => p.Territories)
               .HasForeignKey(d => d.RegionId)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_Territories_Region");
    }
}
