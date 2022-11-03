using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WareHouseApplication.Model;
using WareHouseApplication.Model.EF;

namespace WareHouseApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PalletController : ControllerBase
    {
        private readonly WareHouseDbContext _dbcontext;
        public PalletController(WareHouseDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        [HttpGet]
        public IActionResult GetPallet()
        {
            return Ok(_dbcontext.Pallets.ToList());
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var a = _dbcontext.Pallets.Find(id);
            if (a == null) { return NotFound(); }
            return Ok(a);
        }
        [HttpPost]
        public IActionResult Create(int maximumcapacity)
        {
            try
            {
                _dbcontext.Pallets.Add(new Pallet
                {
                    MaximumCapacity = maximumcapacity
                });
                _dbcontext.SaveChanges();
                return Ok(new{ Success = true });
            }
            catch
            {
                return BadRequest();
            }
            
        }
        [HttpPut("{id}")]
        public IActionResult Edit (int id, int maximumcapacity)
        {
            try
            {
                var pallet = _dbcontext.Pallets.Find(id);
                if(pallet == null) { return NotFound(); }
                pallet.MaximumCapacity = maximumcapacity;
                _dbcontext.SaveChanges();
                return Ok(new { Succes = true });
            }catch
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete (int id)
        {
            try
            {
                var pallet = _dbcontext.Pallets.Find(id);
                if(pallet==null) { return NotFound(); }
                _dbcontext.Pallets.Remove(pallet);
                _dbcontext.SaveChanges();
                return Ok(new { Succes = true });
            }catch
            {
                return BadRequest();
            }
        }
    }
}
