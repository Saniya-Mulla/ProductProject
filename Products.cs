using System.ComponentModel.DataAnnotations;

namespace MvcTaskManager.Models
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? Detail { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public int TotalPrice { get; set; }
        public DateTime CreatedDate { get; set; }
        public byte[] Image { get; set; }
    }
}
