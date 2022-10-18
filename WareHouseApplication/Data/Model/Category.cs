using System.Collections.Generic;
using WareHouseApplication.Enum;

namespace WareHouseApplication.Model
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SortOrder { get; set; }
        public Status Status { get; set; }
        public List<ProductInCategory> ProductInCategories { get; set; }
    }
}
