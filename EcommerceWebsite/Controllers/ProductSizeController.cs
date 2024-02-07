using EcommerceWebsite.Db;
using EcommerceWebsite.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceWebsite.Controllers
{
    [Route("productsize/[controller]")]
    public class ProductSizeController : Controller
    {
        private readonly ApplicationProductSizeContext _ps;

        public ProductSizeController(ApplicationProductSizeContext ps)
        {
            _ps = ps;
        }

        [HttpGet("getproductsizebyid")]
        public IActionResult GetProductSizeByID (string productId)
        {
            List<ProductSizeModel> pds = _ps.ProductSizes.Where(x => x.PId == productId).ToList();

            return Ok(pds);
        }

        [HttpPost("setproductsizebyid")]
        public IActionResult SetProductbyID([FromBody] ProductSizeModel psd)
        {
            try
            {
                _ps.Add(psd);
                _ps.SaveChanges();
                return Ok(psd);
            }
            catch
            {
                return StatusCode(500);
            }
        }
        

        

    }
}
