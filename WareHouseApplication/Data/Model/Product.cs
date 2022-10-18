using System;
using System.Collections.Generic;

namespace WareHouseApplication.Model
{
    public class Product
    {
        public int ID { get; set; }
        public string  Name { get; set; }
        public int Cost { get; set; }
        public int Quantity { get; set; }
        public DateTime DataCreated { get; set; }
        public string Notes { get; set; }
        public List<ProductInCategory> ProductInCategories { get; set; }
        public List<InventoryAdjustment> InventorAdjustments { get; set; }
        public List<TransfersDetail> TransfersDetails { get; set; }
        public List<ProductInPallet> ProductInPallets { get; set; }

    }
}
