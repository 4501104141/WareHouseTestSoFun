using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WareHouseApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetCategory()
        {
            try
            {
                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
