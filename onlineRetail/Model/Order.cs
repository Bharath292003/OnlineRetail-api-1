using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace onlineRetail.Model
{
    public class Order
    {
        [Key]
        public Guid orderId { get; set; }
        [Required]
        [ForeignKey("Customer")]
        public Guid customerId { get; set; }
        [Required]
        [ForeignKey("Product")]
        public Guid productId { get; set; }
        public int quantity { get; set; }
        public Boolean IsCancel { get; set; }
        public virtual Customer Customer { get; set; }  
        public virtual Product Product { get; set; }
    }
}
