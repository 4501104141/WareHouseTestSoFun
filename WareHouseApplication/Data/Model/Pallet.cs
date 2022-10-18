using System.Collections.Generic;

namespace WareHouseApplication.Model
{
    public class Pallet
    {
        public int Id { get;set; }
        public int ProductId { get; set; }
        public int MaximumCapacity { get; set; }
        public List<ProductInPallet> ProductInPallets { get; set; }
    }
}
