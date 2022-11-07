using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WareHouseApplication.Model.Configuration;

namespace WareHouseApplication.Model.EF
{
    public class WareHouseDbContext : DbContext
    {
        public WareHouseDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ContactConfiguration());
            modelBuilder.ApplyConfiguration(new InventoryAdjustmentConfiguration());
            modelBuilder.ApplyConfiguration(new OperationTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PalletConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ProductInCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductInPalletConfiguration());
            modelBuilder.ApplyConfiguration(new StaffConfiguration());
            modelBuilder.ApplyConfiguration(new TransferConfiguration());
            modelBuilder.ApplyConfiguration(new TransfersDetailConfiguration());
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<InventoryAdjustment> InventoryAdjustments { get; set; }
        public DbSet<OperationType> OperationTypes { get; set; }
        public DbSet<Pallet> Pallets { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductInCategory> ProductInCategories { get; set; }
        public DbSet<ProductInPallet> ProductInPallets { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Transfer> Transfers { get; set; }
        public DbSet<TransfersDetail> TransfersDetails { get; set; }
        public DbSet<NguoiDung> NguoiDungs { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
    }

}
