using System.Collections.Generic;

namespace WareHouseApplication.Model
{
    public class OperationType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Transfer> Transfers { get; set; }
    }
}
