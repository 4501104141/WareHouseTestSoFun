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
        public IActionResult Create(int idPallet, int idProduct, int Quantity)
        {
            try
            {
                var a = new ProductInPallet{ PalletId = idPallet, ProductId = idProduct, Quantity = Quantity };
                var pallet = _dbcontext.Pallets.Find(idPallet);
                var product = _dbcontext.Products.Find(idProduct);
                if (pallet.MaximumCapacity - Quantity > 0 && product.Cost >= Quantity)
                {
                    product.Quantity -= Quantity;
                    pallet.MaximumCapacity = pallet.MaximumCapacity - Quantity;
                    _dbcontext.Pallets.Update(pallet);
                    _dbcontext.Products.Update(product);
                    _dbcontext.ProductInPallets.Add(a);
                    _dbcontext.SaveChanges();
                    return Ok(new { Succes = true });
                }else
                {
                    return Content("Het suc chua || Het hang");
                }
            }catch
            {
                return BadRequest();
            }
        }
        [HttpPut("{idPallet, idProduct}")]
        public IActionResult Update (int idPallet, int idProduct
            , int idPalletUpdate, int idProductUpdate, int Quantity)
        {
            try
            {
                var pallet = _dbcontext.ProductInPallets.Find(idProduct, idPallet);
                if(pallet == null) { return NotFound(); }

                pallet.PalletId = idPalletUpdate;
                pallet.ProductId = idProduct;

                var FindPallet = _dbcontext.Pallets.Find(pallet.PalletId);
                var FindProduct = _dbcontext.Products.Find(pallet.ProductId);

                if(FindPallet.MaximumCapacity >= Quantity && FindProduct.Cost >= Quantity)
                {
                    FindProduct.Cost -= Quantity;
                    FindPallet.MaximumCapacity -= Quantity;
                    _dbcontext.Pallets.Update(FindPallet);
                    _dbcontext.ProductInPallets.Update(pallet);
                    _dbcontext.Products.Update(FindProduct);
                    _dbcontext.SaveChanges();
                    return Ok("Succes");
                }else { return Ok("Het suc chua || Het hang"); }
                
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
                pallet.MaximumCapacity += product.Quantity;
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
