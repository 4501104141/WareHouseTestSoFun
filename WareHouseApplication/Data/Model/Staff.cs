using System.Collections.Generic;

namespace WareHouseApplication.Model
{
    public class Staff
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public List<InventoryAdjustment> InventoryAdjustmentes { get; set; }
    }
}
