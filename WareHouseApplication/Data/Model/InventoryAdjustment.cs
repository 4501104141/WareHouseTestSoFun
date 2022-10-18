using System;

namespace WareHouseApplication.Model
{
    public class InventoryAdjustment
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int OnHandQuantity { get; set; }
        public int CountedQuantity { get; set; }
        public int Difference { get; set; }
        public DateTime DateCreated { get; set; }
        public int StaffId { get; set; }
        public Product Product { get; set; }
        public Staff Staff { get; set; }
    }
}
