using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WareHouseApplication.Enum;
using WareHouseApplication.Model;
using WareHouseApplication.Model.EF;

namespace WareHouseApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransfersDetailsController : ControllerBase
    {
        private readonly WareHouseDbContext _dbcontext;
        public TransfersDetailsController(WareHouseDbContext _a)
        {
            _dbcontext = _a;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_dbcontext.TransfersDetails.ToList());
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var a = _dbcontext.TransfersDetails.Find(id);
            if (a == null) { return NotFound(); }
            return Ok(a);
        }
        [HttpPost]
        public IActionResult Create (int TransferId, int ProductId,
            int Quantity)
        {
            try
            {
                var Product= _dbcontext.Products.Find(ProductId);
                int GiaThanh = Product.Cost; int GiaTong; int SoLuong = Product.Quantity;
                if(Quantity > SoLuong) { return Content("Het hang"); }
                GiaTong = Quantity * GiaThanh;
                var transferDetail = new TransfersDetail
                {
                    TransferId = TransferId,
                    ProductId = ProductId,
                    Quantity = Quantity,
                    Price = GiaTong,
                };
                _dbcontext.TransfersDetails.Add(transferDetail);
                _dbcontext.SaveChanges();

                var Transfer = _dbcontext.Transfers.Find(TransferId);
                //
                if(Transfer.Status == TransferStatus.Done)
                {
                    Product.Quantity -= Quantity;
                }
                //
                _dbcontext.SaveChanges();
                return Ok("Succes");
            }catch
            {
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public IActionResult Update (int id, int TransferId, int ProductId,
            int Quantity)
        {
            try
            {
                var Product = _dbcontext.Products.Find(ProductId);
                int GiaThanh = Product.Cost;
                int GiaTong;
                int SoLuong = Product.Quantity;
                if (Quantity > SoLuong) { return Content("Het hang"); }
                GiaTong = Quantity * GiaThanh;
                var transferDetail = _dbcontext.TransfersDetails.Find(id);
                transferDetail.TransferId = TransferId;
                transferDetail.ProductId = ProductId;
                transferDetail.Quantity = Quantity;
                transferDetail.Price = GiaTong;
                _dbcontext.SaveChanges();

                var Transfer = _dbcontext.Transfers.Find(TransferId);
                if (Transfer.Status == TransferStatus.Done)
                {
                    Product.Quantity -= Quantity;
                }
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
                var a = _dbcontext.TransfersDetails.Find(id);
                if (a == null) { return NotFound(); }
                _dbcontext.TransfersDetails.Remove(a);
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
