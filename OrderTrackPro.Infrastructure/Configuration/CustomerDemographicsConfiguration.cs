namespace OrderTrackPro.Infrastructure.Configuration;

public class CustomerDemographicsConfiguration : IEntityTypeConfiguration<CustomerDemographics>
{
    public void Configure(EntityTypeBuilder<CustomerDemographics> builder)
    {
        builder.HasKey(e => e.CustomerTypeId).IsClustered(false);

        builder.Property(e => e.CustomerTypeId)
            .HasMaxLength(10)
            .IsFixedLength()
            .HasColumnName("CustomerTypeID");
    }
}
