using EcommerceWebsite.Db;
using EcommerceWebsite.Models;
using EcommerceWebsite.Repository.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceWebsite.Controllers
{
   

    [Route("product/[controller]")]
    public class ProductController : Controller
    {
        private readonly IFileService _fileservice;
        private readonly ApplicationProductContext _pd;
        public ProductController(IFileService fileservice,ApplicationProductContext pd )
        {
            this._fileservice = fileservice;
            this._pd = pd;
        }

        [HttpPost("addproducts")]
        public IActionResult AddProduct([FromForm]Product model)
        {
            if(model.ImageFile != null)
            {
                var filename = _fileservice.SaveImage(model.ImageFile);
                if(filename.Item1 == 1) // GETTING THE STATUS CODE
                {
                    model.ProductImage = filename.Item2; // GETTING THE NAME OF THE IAMGE
                    _pd.Add(model);
                    _pd.SaveChanges();
                    Console.WriteLine("Added the file to the db");
                    return Ok(model);
                }
                   
            }
            return StatusCode(500);
            
        }

        [HttpGet("getproductbyid")]
        public IActionResult GetProductByid(int id)
        {
            
            try
            {
                List<Product> produc = _pd.ProductTables.Where(x => x.PId == id).ToList();
                return Ok(produc);
            }
            catch
            {
                return Ok("Error");
            }
        }

        [HttpGet("getallproduct")]
        public IActionResult GetAllProduct()
        {

            try
            {
                List<Product> produc = _pd.ProductTables.ToList();
                Console.WriteLine(produc);
                return Ok(produc);
            }
            catch
            {
                return Ok("Error");
            }
        }


    }
}
