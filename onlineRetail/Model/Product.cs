using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace onlineRetail.Model
{
    public class Product
    {
        [Key]
     
        public Guid productId { get; set; }
        [Required]
        public string ProductName { get; set; }
        public int quantity { get; set; }
        public bool isActive { get; set; }
    }
}
