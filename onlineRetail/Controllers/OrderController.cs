using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using onlineRetail.Model;
using onlineRetail.Repository.IRepository;

namespace onlineRetail.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        public OrderController(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("Orderproduct")]
        public async Task<IActionResult>Orderproduct()
        {
            var orderproduct = await _orderRepository.GetAll();
            if (orderproduct == null)
            {
                return NotFound();
            }
            return Ok(orderproduct);

        }
        [HttpGet("OrderProductbyID")]
        public async Task<IActionResult> OrderProductbyID(Guid ID)
        {
            var orderproduct = await _orderRepository.GetById(ID);
            if (orderproduct == null)
            {
                return NotFound();
            }
            return Ok(orderproduct);
        }
        [HttpPost]
        [Route ("Postorder")]
        public async Task<IActionResult> Postorder(CreateOrder items)
        {
            //Order order =new Order();
            //order.orderId = Guid.NewGuid();
            //order.quantity = items.quantity;
            //order.customerId = items.customerId;
            //order.productId = items.productId;  
            //order.IsCancel = false; 
            var order = await _orderRepository.create(items);
            if (order == null)
            {
                return NotFound();
            }
            return CreatedAtAction(nameof(Orderproduct), new { ID = order.orderId }, order);
        }
        [HttpPut("PutOrderbyId")]
        public async Task<IActionResult> PutOrderbyId(Guid orderId, int quantity)
        {
            var orderproduct = await _orderRepository.update(orderId, quantity);
            if (!(orderproduct))
            {
                return BadRequest();
            }
            return Ok(orderproduct);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteOrder(Guid orderId)
        {
            var orderproduct = await _orderRepository.delete(orderId);
            if(orderproduct == false)
            {
                return NotFound();
            }
            return Ok();

        }
    }
}
