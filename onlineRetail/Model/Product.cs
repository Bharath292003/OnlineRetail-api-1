using System.ComponentModel.DataAnnotations;

namespace onlineRetail.Model
{
    public class Product
    {
        [Key]
        public Guid productId { get; set; }
        public string ProductName { get; set; }
        public int quantity { get; set; }
        public bool isActive { get; set; }
    }
}
