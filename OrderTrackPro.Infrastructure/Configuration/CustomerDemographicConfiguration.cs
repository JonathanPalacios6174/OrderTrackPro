namespace OrderTrackPro.Infrastructure.Configuration;

public class CustomerDemographicConfiguration : IEntityTypeConfiguration<CustomerDemographic>
{
    public void Configure(EntityTypeBuilder<CustomerDemographic> entity)
    {
        entity.HasKey(e => e.CustomerTypeId).IsClustered(false);

        entity.Property(e => e.CustomerTypeId)
            .HasMaxLength(10)
            .IsFixedLength()
            .HasColumnName("CustomerTypeID");
    }
}
