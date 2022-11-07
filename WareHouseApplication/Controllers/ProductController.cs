using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WareHouseApplication.Model;
using WareHouseApplication.Model.EF;
using WareHouseApplication.Service;

namespace WareHouseApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly WareHouseDbContext _dbcontext;
        private readonly IService _service;
        public ProductController(WareHouseDbContext _a, IService service)
        {
            _dbcontext = _a;
            _service = service;
        }
        //[HttpGet]
        //public IActionResult GetProduct()
        //{
        //    return Ok(_dbcontext.Products.ToList());
        //}
        [HttpGet]
        public IActionResult GettAllProducts(string search, double? from, double? to, string sortBy, int page = 1)
        {
            try
            {
                var result = _service.GetAll(search, from, to, sortBy, page);
                return Ok(result);
            }
            catch
            {
                return BadRequest("We can't get the product.");
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var a = _dbcontext.Products.Find(id);
            if (a == null) { return NotFound(); }
            return Ok(a);
        }
        [HttpPost]
        public IActionResult Create(string Name, int Cost,
            int Quantity, string Notes = "")
        {
            _dbcontext.Products.Add(new Product
            {
                Name = Name,
                Cost = Cost,
                Quantity = Quantity,
                DataCreated = DateTime.Today,
                Notes = Notes
            });
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
                if (product == null) { return NotFound(); }
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
