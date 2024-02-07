using System.ComponentModel.DataAnnotations;

namespace EcommerceWebsite.Models
{
    public class CartModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PId { get; set; }

        [Required]
        public int UId { get; set; }

        [Required]
        public string? ProductName { get; set; }

        [Required]
        public string? ProductImage { get; set; }

        [Required]
        public string? ProductSize { get; set; }

        [Required]
        public int ProductQty { get; set; }

        [Required]
        public int ProductPrice { get; set; }

    }
}
