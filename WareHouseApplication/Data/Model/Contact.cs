using System.Collections.Generic;

namespace WareHouseApplication.Model
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public List<Transfer> Transfers { get; set; }
    }
}
