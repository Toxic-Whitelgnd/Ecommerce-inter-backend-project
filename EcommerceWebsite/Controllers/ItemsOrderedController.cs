using EcommerceWebsite.Db;
using EcommerceWebsite.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceWebsite.Controllers
{
    [Route("items/[controller]")]
    public class ItemsOrderedController : Controller
    {
        private readonly ApplicationItemsOrderContext _io;

        public ItemsOrderedController(ApplicationItemsOrderContext io)
        {
            _io = io;
        }
        [HttpGet("itemsbyuid")]
        public IActionResult GetItemsBYUID(int uid)
        {
            try
            {
                List<ItemsOrderedModel> Iom = _io.ItemsOrderedTables.Where(x => x.UId == uid).ToList();
                return Ok(Iom);
            }
            catch {
                return Ok("success");
            }
        }

        [HttpPost("additems")]
        public IActionResult SetItems ([FromBody] ItemsOrderedModel iom)
           
        {
            //Console.WriteLine(iom);
            _io.Add(iom);
            _io.SaveChanges();
            return Ok("Added");
        }

        [HttpDelete("deletebyid")]
        public IActionResult DeletItembyid (int id)
        {
            ItemsOrderedModel io = _io.ItemsOrderedTables.FirstOrDefault(x => x.Id == id);
            _io.Remove(io);
            _io.SaveChanges();
            return Ok("Deleted");

        }


    }
}
