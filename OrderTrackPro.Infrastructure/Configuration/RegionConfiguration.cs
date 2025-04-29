namespace OrderTrackPro.Infrastructure.Configuration;


    

public class RegionConfiguration : IEntityTypeConfiguration<Region>
{
    public void Configure(EntityTypeBuilder<Region> builder)
    {
        builder.HasKey(e => e.RegionId)
               .IsClustered(false);

        builder.ToTable("Region");

        builder.Property(e => e.RegionId)
               .HasColumnName("RegionID")
               .ValueGeneratedNever();

        builder.Property(e => e.RegionDescription)
               .IsRequired()
               .HasMaxLength(50)
               .IsFixedLength();
    }
}
