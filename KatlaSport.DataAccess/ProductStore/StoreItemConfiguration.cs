using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace KatlaSport.DataAccess.ProductStore
{
    internal sealed class StoreItemConfiguration : EntityTypeConfiguration<StoreItem>
    {
        public StoreItemConfiguration()
        {
            ToTable("product_store_items");
            HasKey(i => i.Id);
            HasRequired(i => i.Product).WithMany(i => i.Items).HasForeignKey(i => i.ProductId);
            HasRequired(i => i.HiveSection).WithMany(i => i.Items).HasForeignKey(i => i.HiveSectionId);
            Property(i => i.Id).HasColumnName("product_store_item_id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(i => i.Quantity).HasColumnName("product_store_item_quantity").IsRequired();
            Property(i => i.HiveSectionId).HasColumnName("product_store_item_hive_section_id");
            Property(i => i.ProductId).HasColumnName("product_store_item_product_id").IsRequired();
            Property(i => i.IsDelivered).HasColumnName("delivered").IsRequired();
            Property(i => i.IsDeleted).HasColumnName("deleted").IsRequired();
        }
    }
}
