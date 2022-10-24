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
    public class CategoryController : ControllerBase
    {
        private readonly WareHouseDbContext _dbcontext;
        public CategoryController(WareHouseDbContext _a)
        {
            _dbcontext = _a;
        }
        [HttpGet]
        public List<Category> GetProducts()
        {
            return _dbcontext.Categories.ToList();
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var a = _dbcontext.Categories.Find(id);
            if (a == null) { return NotFound(); }
            return Ok(a);
        }
        [HttpPost]
        public IActionResult Create(string Name,int SortOrder, Status status)
        {
            _dbcontext.Categories.Add(new Category
            {
                Name = Name,
                SortOrder = SortOrder,
                Status = status
            });
            _dbcontext.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                var a = _dbcontext.Categories.Find(id);
                if (a == null) { return NotFound(); }
                _dbcontext.Categories.Remove(a);
                _dbcontext.SaveChanges();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
