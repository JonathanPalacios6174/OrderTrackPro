namespace OrderTrackPro.Infrastructure.Configuration;

    public class CategoriesConfiguration: IEntityTypeConfiguration<Categories> 
{
    public void Configure(EntityTypeBuilder<Categories> builder)
    {
        builder.ToTable("Categories");

        builder.HasKey(e => e.CategoryId);

        builder.HasIndex(e => e.CategoryName)
               .HasDatabaseName("CategoryName");

        builder.Property(e => e.CategoryId)
               .HasColumnName("CategoryID");

        builder.Property(e => e.CategoryName)
               .IsRequired()
               .HasMaxLength(15);

        builder.Property(e => e.Picture)
               .HasColumnType("image");
    }
}


