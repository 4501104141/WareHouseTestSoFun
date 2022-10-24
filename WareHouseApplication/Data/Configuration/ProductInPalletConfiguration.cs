using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace WareHouseApplication.Model.Configuration
{
    public class ProductInPalletConfiguration : IEntityTypeConfiguration<ProductInPallet>
    {
        public void Configure(EntityTypeBuilder<ProductInPallet> builder)
        {
            builder.ToTable("ProductInPallets");
            builder.HasKey(t => new { t.ProductId, t.PalletId });
            builder.HasOne(t => t.Pallet).WithMany(pc => pc.ProductInPallets)
                .HasForeignKey(pc => pc.PalletId);
            builder.HasOne(t => t.Product).WithMany(pc => pc.ProductInPallets)
                .HasForeignKey(pc => pc.ProductId);
        }
    }
}
