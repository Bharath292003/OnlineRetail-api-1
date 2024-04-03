using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using onlineRetail.Model;
using onlineRetail.Repository;
using onlineRetail.Repository.IRepository;

namespace onlineRetail.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        [HttpGet]
        [Route("Getcustomer")]
        public async Task<IActionResult>Getcustomer()
        { 
            var proget = await _customerRepository.GetAll();
            if(proget == null)
            {
                return NotFound();
            }
            return Ok(proget);

        }
        [HttpGet("GetcustomerbyID")]
        public async Task<IActionResult> GetcustomerbyID(Guid ID)
        {

            var products = await _customerRepository.GetById(ID);
            if (products == null)
            {
                return NotFound();
            }
            return Ok(products);
        }
        [HttpGet("GetcustomerbyName/{Name}")]
        public async Task<IActionResult> GetcustomerbyName(string Name)
        {
       
            var products = await _customerRepository.GetByName(Name);
            if (products == null)
            {
                return NotFound();
            }
            return Ok(products);
        }
        [HttpPost]
        public async Task<IActionResult> Postproduct(Customer pro)
        {
            var customerpost = await _customerRepository.Create(pro);
            return CreatedAtAction(nameof(GetcustomerbyID), new { ID = pro.customerId }, pro);
        }
        [HttpPut("PutCustomerbyId")]
        public async Task<IActionResult> PutCustomerbyId(Guid customerId, Customer pro)
        {
            var put = await _customerRepository.Update(customerId, pro);
            if (!put)
            {
                return BadRequest();
            }
            return Ok(put);
        }
        
        [HttpDelete]
        public async Task<IActionResult> DeleteCustomer(Guid id)
        {
            var customerdel = await _customerRepository.Delete(id);
            if (customerdel == false)
            {
                return NotFound();
            }
            return Ok();

        }
    }
}

