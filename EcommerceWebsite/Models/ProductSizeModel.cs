using System.ComponentModel.DataAnnotations;

namespace EcommerceWebsite.Models
{
    public class ProductSizeModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? PId { get; set; }

        [Required]
        public string? ProductSize { get; set; }

        [Required]
        public string? ProductRating { get; set; }
    }
}
