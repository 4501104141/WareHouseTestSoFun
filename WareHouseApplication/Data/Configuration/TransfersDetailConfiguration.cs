using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace WareHouseApplication.Model.Configuration
{
    public class TransfersDetailConfiguration : IEntityTypeConfiguration<TransfersDetail>
    {
        public void Configure(EntityTypeBuilder<TransfersDetail> builder)
        {
            builder.ToTable("TransfersDetails");
            builder.HasKey(x => x.TransferId);
            builder.Property(x => x.Quantity).HasDefaultValue(0);
            builder.HasOne(t => t.Transfer).WithMany(pc => pc.TransfersDetails)
                .HasForeignKey(pc => pc.TransferId);
            builder.HasOne(t => t.Product).WithMany(pc => pc.TransfersDetails)
                .HasForeignKey(pc => pc.ProductId);
        }
    }
}
