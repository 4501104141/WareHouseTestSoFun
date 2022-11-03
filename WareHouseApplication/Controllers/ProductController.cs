using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WareHouseApplication.Model;
using WareHouseApplication.Model.EF;

namespace WareHouseApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly WareHouseDbContext _dbcontext;
        public ProductController (WareHouseDbContext _a)
        {
            _dbcontext = _a;
        }
        [HttpGet]
        public IActionResult GetProduct()
        {
            return Ok(_dbcontext.Products.ToList());
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var a = _dbcontext.Products.Find(id);
            if(a == null) { return NotFound(); }
            return Ok(a);
        }
        [HttpPost]
        public IActionResult Create(string Name,int Cost,
            int Quantity, string Notes = "")
        {
            _dbcontext.Products.Add(new Product{Name = Name, Cost = Cost,
            Quantity = Quantity, DataCreated = DateTime.Today, Notes = Notes});
            _dbcontext.SaveChanges();
            return Ok(new
            {
                Success = true,
            });
        }
        [HttpPut("{id}")]
        public IActionResult Edit(int id, string Name, int Cost,
            int Quantity, string Notes = "")
        {
            try
            {
                var product = _dbcontext.Products.Find(id);
                if(product == null ) { return NotFound(); }
                product.Name = Name;
                product.Cost = Cost;
                product.Quantity = Quantity;
                product.Notes = Notes;
                _dbcontext.SaveChanges();
                return Ok(product.Name);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var a = _dbcontext.Products.Find(id);
            if (a == null) { return NotFound(); }
            _dbcontext.Products.Remove(a);
            _dbcontext.SaveChanges();
            return Ok();
        }
    }
}
