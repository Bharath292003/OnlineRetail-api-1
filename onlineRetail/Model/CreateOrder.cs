using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace onlineRetail.Model
{
    public class CreateOrder
    {
        
        public Guid customerId { get; set; }
  
        public Guid productId { get; set; }
        public int quantity { get; set; }

    }
}
