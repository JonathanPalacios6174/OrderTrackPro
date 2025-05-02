
namespace OrderTrackPro.Infrastructure.Configuration;

 public class CategoryConfiguration: IEntityTypeConfiguration<Category> 
{
    public void Configure(EntityTypeBuilder<Category> entity)
    {
        entity.HasIndex(e => e.CategoryName, "CategoryName");

        entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
        entity.Property(e => e.CategoryName)
            .IsRequired()
            .HasMaxLength(15);
        entity.Property(e => e.Picture).HasColumnType("image");
    }
}






























