namespace WareHouseApplication.Model
{
    public class TransfersDetail
    {
        public int TransferId { get; set; }
        public int ProductId {get;set;}
        public int Quantity { get; set; }
        public int Price { get; set; }
        public Transfer Transfer { get; set; }
        public Product Product { get; set; }
    }
}
