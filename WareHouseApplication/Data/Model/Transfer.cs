using System;
using System.Collections.Generic;
using WareHouseApplication.Enum;

namespace WareHouseApplication.Model
{
    public class Transfer
    {
        public int Id { get; set; }
        public int ContactId { get; set; }
        public int OperationTypeID { get; set; }
        public DateTime DateCreated { get; set; }
        public string Notes { get; set; }
        public TransferStatus Status{ get; set; }
        public List<TransfersDetail> TransfersDetails { get; set; }
        public Contact Contact { get; set; }
        public OperationType OperationType { get; set; }
    }
}
