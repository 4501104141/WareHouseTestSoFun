using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace WareHouseApplication.Model.Configuration
{
    public class InventoryAdjustmentConfiguration : IEntityTypeConfiguration<InventoryAdjustment>
    {
        public void Configure(EntityTypeBuilder<InventoryAdjustment> builder)
        {
            builder.ToTable("InventoryAdjustments");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.HasOne(x => x.Product).WithMany(x => x.InventorAdjustments)
                .HasForeignKey(x => x.ProductId);
            builder.HasOne(x => x.Staff).WithMany(x => x.InventoryAdjustmentes)
                .HasForeignKey(x => x.StaffId);
        }
    }
}
