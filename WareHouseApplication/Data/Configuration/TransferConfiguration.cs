using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WareHouseApplication.Enum;

namespace WareHouseApplication.Model.Configuration
{
    public class TransferConfiguration : IEntityTypeConfiguration<Transfer>
    {
        public void Configure(EntityTypeBuilder<Transfer> builder)
        {
            builder.ToTable("Transfers");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Status).HasDefaultValue(TransferStatus.NotDone);

            builder.HasOne(t => t.Contact).WithMany(pc => pc.Transfers)
                .HasForeignKey(pc => pc.ContactId);
            builder.HasOne(t => t.OperationType).WithMany(pc => pc.Transfers)
                .HasForeignKey(pc => pc.OperationTypeID);
        }
    }
}
