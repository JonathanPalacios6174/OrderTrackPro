using Microsoft.AspNetCore.Mvc;
using OrderTrackPro.Application.DTOs;
using OrderTrackPro.Application.Interfaces;

namespace OrderTrackPro.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : Controller
    {
       private readonly IOrderInterfaceService _orderInterfaceService;
        public OrderController(IOrderInterfaceService orderInterfaceService)
        {
            _orderInterfaceService = orderInterfaceService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _orderInterfaceService.GetOrdersAsync();
            return Ok(orders);
        }

        [HttpPost("Create")]

        public async Task<IActionResult> CreateOrder(OrderDTO orderDTO)
        {
            return Ok(await _orderInterfaceService.CreateOrder(orderDTO));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateOrder(OrderDTO orderDTO)
        {
            return Ok(await _orderInterfaceService.UpdateOrder(orderDTO));
        }

        [HttpDelete("Delete")]

        public async Task<IActionResult> DeleteOrder(OrderDTO orderDTO)
        {
            
            return Ok(await _orderInterfaceService.DeleteOrder(orderDTO));
        }

    }
}
