namespace WareHouseApplication.Model
{
    public class ProductInPallet
    {
        public int PalletId { get; set; }
        public Pallet Pallet { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
