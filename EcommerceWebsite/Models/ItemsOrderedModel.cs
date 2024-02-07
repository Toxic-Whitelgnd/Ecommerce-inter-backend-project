using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace EcommerceWebsite.Models
{
    public class ItemsOrderedModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PId { get; set; }

        [Required]
        public int UId { get; set; }

        public string? ProductName { get; set; }

        public string? ProductImage { get; set; }

    
        public string? ProductSize { get; set; }

      
        public int ProductQty { get; set; }

        public int ProductPrice { get; set; }

        public int ProductTotal { get; set; }

        public int Total { get; set; }

        public string? Paymentid { get; set; }

        public string? Date {  get; set; }

        public string? Time { get; set; }
    }
}
