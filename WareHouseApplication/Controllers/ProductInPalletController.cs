using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WareHouseApplication.Model;
using WareHouseApplication.Model.EF;

namespace WareHouseApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductInPalletController : ControllerBase
    {
        private readonly WareHouseDbContext _dbcontext;
        public ProductInPalletController(WareHouseDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        [HttpGet]
        public IActionResult GetProductInPallet()
        {
            return Ok(_dbcontext.ProductInPallets.ToList());
        }
        [HttpGet("{idPallet}")]
        public IActionResult GetProductInPalletById(int idPallet, int idProduct)
        {
            var a = _dbcontext.ProductInPallets.Find(idProduct, idPallet);
            if (a == null) { return NotFound(); }
            return Ok(a);
        }
        [HttpPost]
        public IActionResult Create(int idPallet, int idProduct)
        {
            try
            {
                var a = new ProductInPallet{ PalletId = idPallet, ProductId = idProduct };
                var pallet = _dbcontext.Pallets.Find(idPallet);
                var product = _dbcontext.Products.Find(idProduct);

                if(pallet.MaximumCapacity - product.Quantity > 0)
                {
                    pallet.MaximumCapacity = pallet.MaximumCapacity - product.Quantity;
                    _dbcontext.Pallets.Update(pallet);
                    _dbcontext.ProductInPallets.Add(a);
                    _dbcontext.SaveChanges();
                    return Ok(new { Succes = true });
                }else
                {
                    return Content("Het suc chua");
                }
            }catch
            {
                return BadRequest();
            }
        }
        [HttpPut("{idPallet, idProduct}")]
        public IActionResult Update (int idPallet, int idProduct
            , int idPalletUpdate, int idProductUpdate)
        {
            try
            {
                var pallet = _dbcontext.ProductInPallets.Find(idProduct, idPallet);
                if(pallet == null) { return NotFound(); }
                pallet.PalletId = idPalletUpdate;
                pallet.ProductId = idProduct;
                _dbcontext.SaveChanges();
                return Ok(new { Succes = true });
            }catch
            {
                return BadRequest();
            }
        }
        [HttpDelete]
        public IActionResult Delete (int idPallet, int idProduct)
        {
            try
            {
                var ProductInPallet = _dbcontext.ProductInPallets.Find(idProduct, idPallet);
                if (ProductInPallet == null) { return NotFound(); }

                var pallet = _dbcontext.Pallets.Find(idPallet);
                var product = _dbcontext.Products.Find(idProduct);
                pallet.MaximumCapacity = pallet.MaximumCapacity + product.Quantity;
                _dbcontext.Pallets.Update(pallet);

                _dbcontext.ProductInPallets.Remove(ProductInPallet);
                _dbcontext.SaveChanges();
                return Ok(new { Succes = true });
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
