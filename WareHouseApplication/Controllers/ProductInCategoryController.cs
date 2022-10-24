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
    public class ProductInCategoryController : ControllerBase
    {
        private readonly WareHouseDbContext _dbcontext;
        public ProductInCategoryController(WareHouseDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        [HttpGet]
        public List<ProductInCategory> GetProductInCategory()
        {
            return _dbcontext.ProductInCategories.ToList();
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int idProduct = -1, int idCategories = -1)
        {
            if (idProduct == -1 && idCategories != -1)
            {
                var a = _dbcontext.ProductInCategories.Find(idCategories);
                if (a == null) { return NotFound(); }
                return Ok(a);
            }
            else if (idProduct != -1 && idCategories == -1)
            {
                var a = _dbcontext.ProductInCategories.Find(idProduct);
                if (a == null) { return NotFound(); }
                return Ok(a);
            }
            else
            {
                var a = _dbcontext.ProductInCategories.Find(idProduct, idCategories);
                if (a == null) { return NotFound(); }
                return Ok(a);
            }
        }
        [HttpPost]
        public IActionResult Create(int idProduct = -1, int idCategory = -1)
        {
            try
            {
                if (idProduct != -1 && idCategory != -1)
                {
                    _dbcontext.ProductInCategories.Add(new ProductInCategory
                    {
                        ProductId = idProduct,
                        CategoryId = idCategory
                    });
                    _dbcontext.SaveChanges();
                    return Ok();
                }
                else
                {
                    return Content("Moi ban nhap day du");
                }
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete]
        public IActionResult Delete(int idProduct=0 , int idCategory=0)
        {
            var begin = new ProductInCategory();
            begin.ProductId = idProduct;
            begin.CategoryId = idCategory;
            try
            {
                var a = _dbcontext.ProductInCategories.Find(new ProductInCategory
                {
                    ProductId = idProduct,
                    CategoryId = idCategory
                });
                if (a == null) { return NotFound(); }
                _dbcontext.ProductInCategories.Remove(a);
                _dbcontext.SaveChanges();
                return Ok();
            }catch
            {
                return BadRequest();
            }
        }
    }
}
