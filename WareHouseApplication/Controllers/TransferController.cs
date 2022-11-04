using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using WareHouseApplication.Enum;
using WareHouseApplication.Model;
using WareHouseApplication.Model.EF;

namespace WareHouseApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferController : ControllerBase
    {
        private readonly WareHouseDbContext _dbcontext;
        public TransferController(WareHouseDbContext _a)
        {
            _dbcontext = _a;
        }
        // int id, int ContacId, int OperationTypeID,
        // DateCreated Datetime.Now, string Notes, Status Status
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_dbcontext.Transfers.ToList());
        }
        [HttpGet("{id}")]
        public IActionResult GetById (int id)
        {
            var a = _dbcontext.Transfers.Find(id);
            if(a==null) { return NotFound(); }
            return Ok(a);
        }
        [HttpPost]
        public IActionResult Create(int ContactId, int OperationTypeID, string Notes, TransferStatus status)
        {
            try
            {
                var a = new Transfer
                {
                    ContactId = ContactId,
                    OperationTypeID = OperationTypeID,
                    Notes = Notes,
                    DateCreated = DateTime.Now,
                    Status = status
                };
                _dbcontext.Transfers.Add(a);
                _dbcontext.SaveChanges();
                return Ok("Succes");
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, int ContactId, int OperationTypeID, string Notes, TransferStatus status)
        {
            try
            {
                var transfer = _dbcontext.Transfers.Find(id);
                if (transfer == null) { return NotFound(); }
                transfer.ContactId = ContactId;
                transfer.OperationTypeID = OperationTypeID;
                transfer.Notes = Notes;
                transfer.Status = status;
                _dbcontext.SaveChanges();
                return Ok("Succes");
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                var a = _dbcontext.Transfers.Find(id);
                if(a==null) { return NotFound(); }
                _dbcontext.Transfers.Remove(a);
                _dbcontext.SaveChanges();
                return Ok("Succes");
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
