using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace onlineRetail.Model
{
    public class Customer
    {
        [Key]
        public Guid customerId { get; set; }
        [Required]
        public string? customerName { get; set; }
        public string? mobile { get; set; }
        public string? emailID { get; set; }
    }
}
