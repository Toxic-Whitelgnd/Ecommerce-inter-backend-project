using EcommerceWebsite.Db;
using EcommerceWebsite.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceWebsite.Controllers
{
    [Route("cart/[controller]")]

    
    public class CartController : Controller
    {
        private readonly ApplicationCartContext _ci;

        public CartController(ApplicationCartContext ci)
        {
            _ci = ci;
        }

        [HttpPost("addtocart")]
        public IActionResult AddtoCart([FromBody] CartModel cm)
        {
            int pdid = cm.PId;
            string size = cm.ProductSize;
            Console.WriteLine("Sizee"+ size);
        
            CartModel cd = null;
            foreach (var item in _ci.CartTables)
            {
                if (item.PId == pdid && item.ProductSize == size)
                {
                    cd = item;
                    break;
                }
            }
         
            if (cd == null)
            {
                _ci.Add(cm);
                _ci.SaveChanges();
                return Ok(cm);
            }
            else if (cd.ProductSize == size)
            {
                int iqty = cd.ProductQty+1;
                cd.ProductQty = iqty;
                _ci.Update(cd);
                _ci.SaveChanges();
                return Ok("ItemExist");
            }
            else if(cd.ProductSize != size) 
            {
                _ci.Add(cm);
                _ci.SaveChanges();
                return Ok(cm);
            }
            else
            {
                return Ok("Error");
            }
            
            
               
        }

        [HttpGet("getcartbyuid")]
        public IActionResult GetByUID(int uid)
        {
            try
            {
                List<CartModel> cm = _ci.CartTables.Where(x => x.UId == uid).ToList();
                return Ok(cm);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPut("updatecartbyuid")]
        public IActionResult UpdateByUID(CartModel cm)
        {
            try
            {
                _ci.Update(cm);
                _ci.SaveChanges();
                return Ok(cm);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("deletebypid")]
        public IActionResult DeleteByPID(int pid)
        {
            try
            {
                CartModel ci = _ci.CartTables.FirstOrDefault(x => x.PId == pid);
                _ci.Remove(ci);
                _ci.SaveChanges();
                return Ok("Deleted");
            }
            catch
            {
                return Ok("Not deleted");
            }
        }
    }
}
