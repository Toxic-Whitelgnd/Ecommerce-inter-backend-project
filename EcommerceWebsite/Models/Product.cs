using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceWebsite.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PId { get; set; }

        [Required]
        public string? ProductName { get; set; }

        [Required]
        public string? ProductDescription { get; set; }

        [Required]
        public string? ProductCategory { get; set; }
        
        [Required]
        public string? ProductQty { get; set; }

        [Required]
        public string? ProductOrginalPrice { get; set; }

        [Required]
        public string? ProductOfferPrice { get; set; }

        [Required]
        public string? ProductImage { get; set; }
        // next folder creation abstarction and repositary for storing the images :TODO: DObe
        // add controller and appsetting.json and progrm.cs
        [NotMapped]
        public IFormFile? ImageFile { get; set; }

    }
}
